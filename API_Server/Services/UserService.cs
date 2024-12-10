using API_Server.Models;
using API_Server.DTOs;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_Server.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;
        private readonly IMongoCollection<Group> groups;

        private EmailService emailService;
        private readonly Dictionary<string, User> _users;
        private string? _currentOtp;
        private string? _currentEmail;


        public UserService(MongoDbService db, EmailService email) {
            users = db.Users;
            groups = db.ChatGroup;
            emailService = email;
            _users = new Dictionary<string, User>();
        }
         
        public async Task<List<User>> GetAllUserAsync() => await users.Find(_ =>  true).ToListAsync();

        public async Task<(List<User>, int)>SearchUserAsync(string query, int page, int pageSize, string username)
        {
            if(page <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Page và PageSize phải lớn hơn 0");
            }

            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Or(
                    Builders<User>.Filter.Regex("Name", new BsonRegularExpression(query, "i")),
                    Builders<User>.Filter.Regex("Email", new BsonRegularExpression(query, "i")),
                    Builders<User>.Filter.Regex("Username", new BsonRegularExpression(query, "i"))
                    ),
                Builders<User>.Filter.Ne("Username", username)
            );
            var total = await users.CountDocumentsAsync(filter);

            var usersFound = await users.Find(filter).Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();
            
            int totalPages = (int)Math.Ceiling((double)total / pageSize);
            return (usersFound, totalPages);
        }
         
        public async Task<List<User>> GetUserByGroupId(string id)
        {
            return await users.Find(u => u.ChatGroup.Contains(id)).ToListAsync();
        }
        public async Task<User> GetUserById(string id)
        {
            return await users.Find(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        }
        public async Task<User> GetUserByUserName(string userName)
        {
            return await users.Find(u => u.Username == userName).FirstOrDefaultAsync();
        }
        public async Task UpdateUser(User user)
        {
            await users.ReplaceOneAsync(u => u.Username == user.Username, user);
        }
        public async Task<bool> IsJoined(string username, string groupId)
        {
            var user = await GetUserByUserName(username);
            if (user == null)
            {
                return false;
            }
            
            if (!user.ChatGroup.Contains(groupId))
            {
                return false;
            }
            return true;
        }
        public async Task<bool> AddGroupToUser(string username, string groupId)
        {
            var isJoined = await IsJoined(username, groupId);
            if (isJoined)
            {
                return false;
            }
            var update = Builders<User>.Update.AddToSet(u => u.ChatGroup, groupId);
            await users.UpdateOneAsync(u => u.Username == username, update);
            return true;
        }
        public async Task<List<string>> GetRequestList(string username)
        {
            var user = await GetUserByUserName(username);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            List<string> reqList = user.FriendRequests;
            
            return reqList;
        }
        public async Task<bool> SendRequest(string username, string targetUsername)
        {
            var user = await GetUserByUserName(username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var targetUser = await GetUserByUserName(targetUsername);
            if (targetUser == null)
            {
                throw new Exception("targetUser not found");
            }

            if (user.Friends.Contains(targetUser.Username))
            {
                throw new Exception("Hai người đã là bạn!");
            }

            if (targetUser.FriendRequests.Contains(user.Username))
            {
                throw new Exception("Bạn đã gửi lời mời rồi!");
            }

            targetUser.FriendRequests.Add(username);

            await UpdateUser(targetUser);
            return true;
        }
        public async Task<bool> AcceptFriendRequest(string username, string requestUsername)
        {
            var user = await GetUserByUserName(username);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            var requestUser = await GetUserByUserName(requestUsername);
            if (requestUser == null)
            {
                throw new Exception("Request user not found!");
            }

            if (!user.FriendRequests.Contains(requestUser.Username))
            {
                throw new Exception("Không có lời mời từ người dùng này!");
            }
            user.FriendRequests.Remove(requestUsername);
            user.Friends.Add(requestUser.Username);
            requestUser.Friends.Add(user.Username);
            await UpdateUser(user);
            await UpdateUser(requestUser); return true;
        }
        public async Task<List<string>> GetListFriendIdByUsername(string username)
        {
            var user = await users.Find(u => u.Username == username).FirstOrDefaultAsync();
            return user?.Friends ?? new List<string>();
        }
        public async Task<List<User>> SuggestFriendAsync(string username)
        {
            var userFound = await GetUserByUserName(username);
            if (userFound == null) { return null; }

            var userGroups = userFound.ChatGroup;
            var members = await groups
                .Find(g => userGroups.Contains(g.Id.ToString()))
                .Project(g => g.Members)
                .ToListAsync();
            var allMembers = members.SelectMany(m => m).Distinct().ToList();

            allMembers.Remove(username);
            allMembers.RemoveAll(m => userFound.Friends.Contains(m));

            var suggestFriends = await users.Find(u => allMembers.Contains(u.Username)).ToListAsync();

            return suggestFriends;
        }
        public async Task<bool> AddFriend(string userId, string friendId)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id.ToString(), userId);
            var update = Builders<User>.Update.AddToSet(u => u.Friends, friendId);

            var res = await users.UpdateOneAsync(filter, update);

            return res.ModifiedCount > 0;
        }
        public async Task<bool> IsFriend(string username, string friendName)
        {
            var user = await GetUserByUserName(username);
            if (user == null) { return false; }
            var friend = await GetUserByUserName(friendName);
            if (friend == null) { return false; }
            if(!user.Friends.Contains(friendName)) { return false; }
            return true;
        }
        public async Task<bool> DeleteRequest(string username, string reqUsername)
        {
            try
            {
                var user = await GetUserByUserName(username);
                if (user == null) { throw new Exception("User not found!"); }
                var reqUser = await GetUserByUserName(reqUsername);
                if (reqUser == null) { throw new Exception("reqUser not found!"); }
                user.FriendRequests.Remove(reqUser.Username);
                await UpdateUser(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa yêu cầu: {ex.Message}");
            }
        }
        public async Task<bool> DeleteSendingRequest(string username, string reqUsername)
        {
            try
            {
                var user = await GetUserByUserName(username);
                if (user == null) { throw new Exception("User not found!"); }
                var reqUser = await GetUserByUserName(reqUsername);
                if (reqUser == null) { throw new Exception("reqUser not found!"); }
                reqUser.FriendRequests.Remove(username);
                await UpdateUser(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa yêu cầu: {ex.Message}");
            }
        }
        public async Task DeleteFriend(string username, string friendName)
        {
            try
            {
                var user = await GetUserByUserName(username);
                if (user == null) { throw new Exception("User not found!"); }
                var friend = await GetUserByUserName(friendName);
                if (friend == null) { throw new Exception("Friend not found!"); }
                friend.Friends.Remove(username);
                user.Friends.Remove(friendName);
                await UpdateUser(user);
                await UpdateUser(friend);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public async Task<List<Group>> GetGroupsByUsername(string username)
        {
            try
            {
                var user = await GetUserByUserName(username);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                var groupsFound = await groups.Find(g => g.Members.Contains(username)).ToListAsync();
                return groupsFound;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tải nhóm: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> RegisterAsync(Register registerModel)
        {
            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                return (false, "Mật khẩu xác nhận không hợp lệ.");
            }

            var filter = Builders<User>.Filter.Or(
                Builders<User>.Filter.Eq(u => u.Username, registerModel.Username),
                Builders<User>.Filter.Eq(u => u.Email, registerModel.Email)
            );

            var existingUser = await users.Find(filter).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                return (false, "Tên người dùng hoặc email đã tồn tại.");
            }

            var otp = new Random().Next(100000, 999999).ToString();
            _currentOtp = otp;

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerModel.Password);

            var user = new User
            {
                Name = registerModel.Name,
                Username = registerModel.Username,
                Password = registerModel.Password,
                PasswordHash = hashedPassword,
                DateOfBirth = registerModel.DateOfBirth.Date,
                Email = registerModel.Email,
                CreatedAt = DateTime.UtcNow
            };

            _users[registerModel.Email] = user;

            _currentEmail = user.Email;
            emailService.SendOtpEmail(user.Email, otp);

            return (true, "Đăng kí thành công. Kiếm tra mã OTP trong email của bạn.");
        }
        public async Task<(bool Success, string Message, UserDTO? UserDto)> VerifyOtpAsync(Otp otpModel)
        {
            if (string.IsNullOrEmpty(_currentEmail))
            {
                return (false, "Email này chưa được dùng để đăng kí.", null);
            }

            if (!_users.ContainsKey(_currentEmail))
            {
                return (false, "Không tìm thấy thông tin người dùng.", null);
            }
            var tempUser = _users[_currentEmail];

            if (_currentOtp != otpModel.OTP)
            {
                return (false, "OTP không hợp lệ", null);
            }

            var filter = Builders<User>.Filter.Eq(u => u.Email, tempUser.Email);
            var existingUser = await users.Find(filter).FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return (false, "Người dùng đã được đăng kí.", null);
            }

            var newUser = new User
            {
                Name = tempUser.Name,
                Username = tempUser.Username,
                PasswordHash = tempUser.PasswordHash,
                DateOfBirth = tempUser.DateOfBirth,
                Email = tempUser.Email,
                CreatedAt = DateTime.UtcNow,
                IsEmailVerified = true
            };

            await users.InsertOneAsync(newUser);

            var userDto = new UserDTO
            {
                Name = newUser.Name,
                Username = newUser.Username,
                Email = newUser.Email,
                DateOfBirth = newUser.DateOfBirth,
                Status = newUser.Status,
                IsEmailVerified = newUser.IsEmailVerified,
                CreatedAt = newUser.CreatedAt
            };

            _users.Remove(_currentEmail);
            _currentOtp = string.Empty;
            _currentEmail = string.Empty;

            return (true, "Đăng kí thành công!", userDto);
        }
        public async Task<(bool Success, string Message, User? User)> LoginAsync(Login loginModel, HttpResponse response)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                return (false, "Yêu cầu đăng nhập thất bại.", null);
            }

            var filter = Builders<User>.Filter.Eq(u => u.Username, loginModel.Username);
            var user = await users.Find(filter).FirstOrDefaultAsync();

            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
            {
                return (false, "Tên người dùng không hợp lệ.", null);
            }

            if (!BCrypt.Net.BCrypt.Verify(loginModel.Password, user.PasswordHash))
            {
                return (false, "Mật khẩu không hợp lệ.", null);
            }

            return (true, "Đăng nhập thành công", user);
        }
    }
}
