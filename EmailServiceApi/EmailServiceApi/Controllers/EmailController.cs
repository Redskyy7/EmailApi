using EmailServiceApi.Services;
using EmailServiceApi.Models;   
using Microsoft.AspNetCore.Mvc;

namespace EmailServiceApi.Controllers
{
    [Route("api/mails")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendMail([FromBody] SendEmailModel sendEmailModel)
        {
            _emailService.SendMail(sendEmailModel.Emails, sendEmailModel.Subject, sendEmailModel.Body, sendEmailModel.IsHtml);

            return Ok();
        }
    }
}
