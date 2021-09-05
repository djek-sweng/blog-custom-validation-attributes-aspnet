using Microsoft.AspNetCore.Mvc;
using Validation.Attributes;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpPost]
        [Route("test-letters-only")]
        public IActionResult TestLettersOnly([FromQuery] [LettersOnly] string text)
        {
            /* Place your business code here. */

            return Ok(text);
        }

        [HttpPost]
        [Route("test-of-legal-age")]
        public IActionResult TestOfLegalAge([FromQuery] [OfLegalAge] int value)
        {
            /* Place your business code here. */

            return Ok(value);
        }

        [HttpPost]
        [Route("test-user")]
        public IActionResult TestUser([FromBody] User user)
        {
            /* Place your business code here. */

            return Ok(user);
        }
    }
}