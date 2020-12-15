using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using AppointmentScheduler.Core.Interface;
using Microsoft.Extensions.Configuration;

namespace AppointmentScheduler.Core.Service
{
    public class EmailService : IEmailService
    {
        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Send(string @from, string to, string subject, string html)
        {
            var host = Configuration["EmailSettings:host"];
            var port = Int16.Parse(Configuration["EmailSettings:port"]);
            var user = Configuration["EmailSettings:user"];
            var password = Configuration["EmailSettings:password"];

            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(host, port, SecureSocketOptions.StartTls);
            smtp.Authenticate(user, password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}