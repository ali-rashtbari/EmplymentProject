using Employment.Application.Contracts.InfrastructureContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _fromEmailAddress;

        public EmailSender(string smtpServer, int smtpPort, string fromEmailAddress)
        {
            _fromEmailAddress = fromEmailAddress;
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MailMessage()
            {
                From = new MailAddress(_fromEmailAddress),
                Subject = subject,
                Body = message,
                IsBodyHtml = false,
            };
            emailMessage.To.Add(new MailAddress(email));
            using var smtpClient = new SmtpClient(_smtpServer, _smtpPort);
            smtpClient.Send(emailMessage);
            return Task.CompletedTask;
        }
    }
}
