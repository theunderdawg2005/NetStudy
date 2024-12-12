using API_Server.DTOs;
using API_Server.Models;
using API_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Server.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;
        private readonly JwtService _jwtService;

        public QuestionController(QuestionService questionService, JwtService jwtService)
        {
            _questionService = questionService;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpPost("{username}/create-question")]
        public async Task<IActionResult> CreateQuestion([FromBody] Question question, [FromRoute] string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            if (await _questionService.IsTitleExistsAsync(question.Title, username))
            {
                return BadRequest(new
                {
                    message = "Tiêu đề câu hỏi đã tồn tại."
                });
            }

            try
            {
                var createdQuestion = await _questionService.CreateQuestionAsync(question, username);
                
                return Ok(new
                {
                    message = "Tạo câu hỏi thành công!",
                    info = createdQuestion
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{username}/get-question/{title}")]
        public async Task<IActionResult> GetQuestion(string title, [FromRoute] string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            try
            {
                var question = await _questionService.GetQuestionAsync(title, username);
                if (question == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy câu hỏi!"
                    });
                }

                return Ok(new
                {
                    message = "Question found!",
                    info = question
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{username}/get-random-question")]
        public async Task<IActionResult> GetRandomQuestion([FromRoute] string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            try
            {
                var question = await _questionService.GetRandomQuestionAsync(username);
                if (question == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy câu hỏi!"
                    });
                }

                return Ok(new
                {
                    message = "Lấy câu hỏi ngẫu nhiên thành công!",
                    info = question
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{username}/get-all-questions")]
        public async Task<IActionResult> GetAllQuestions([FromRoute] string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            try
            {
                var questions = await _questionService.GetAllQuestionsAsync(username);
                if (questions == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy câu hỏi!"
                    });
                }

                return Ok(new
                {
                    message = "Lấy danh sách câu hỏi thành công!",
                    info = questions
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{username}/get-correct-answer/{title}")]
        public async Task<IActionResult> GetCorrectAnswer(string title, [FromRoute] string username)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            try
            {
                var correctAnswer = await _questionService.GetCorrectAnswer(title, username);
                if (correctAnswer == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy câu trả lời!"
                    });
                }

                return Ok(new
                {
                    message = "Correct answer found!",
                    info = correctAnswer
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
