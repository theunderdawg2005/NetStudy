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
        public async Task<IActionResult> CreateQuestion([FromRoute] string username, [FromBody] Question question)
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!_jwtService.IsValidate(authorizationHeader))
            {
                return Unauthorized(new
                {
                    message = "Yêu cầu không hợp lệ!"
                });
            }

            if (await _questionService.IsTitleExistsAsync(question.Title, question.Owner))
            {
                return BadRequest(new
                {
                    message = "Tiêu đề câu hỏi đã tồn tại."
                });
            }

            try
            {
                var createdQuestion = await _questionService.CreateQuestionAsync(question);
                
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
        public async Task<IActionResult> GetQuestion(string title)
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
                var question = await _questionService.GetQuestionAsync(title);
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
        [HttpGet("{username}/get-correct-answer/{title}")]
        public async Task<IActionResult> GetCorrectAnswer(string title)
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
                var correctAnswer = await _questionService.GetCorrectAnswer(title);
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
