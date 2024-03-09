using Microsoft.AspNetCore.Identity.UI.Services;

namespace Portfolio.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //will be logic for send email
            return Task.CompletedTask;
        }
    }
}
