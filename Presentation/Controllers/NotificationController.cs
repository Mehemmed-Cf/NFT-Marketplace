using Application.Services;
using Infrastructure.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class NotificationController : Controller
    {
        private readonly EmailService emailService;

        public NotificationController(EmailService emailService)
        {
            this.emailService = emailService;
        }

        public async Task<IActionResult> SendWelcomeEmail(string recipientEmail)
        {
            string subject = "Welcome to Our Service!";
            string body = "<h1>Thank you for joining us!</h1><p>We're excited to have you on board.</p>";

            await emailService.SendEmailAsync(recipientEmail, subject, body);

            return Ok("Email sent successfully.");
        }
    }
}
