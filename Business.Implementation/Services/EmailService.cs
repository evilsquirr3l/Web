using System.Threading.Tasks;
using AutoMapper;
using Business.Abstraction;
using Business.Models;
using Data.Abstraction;
using Data.Entities;
using MailKit.Net.Smtp;
using MimeKit;
using User = Data.Entities.User;

namespace Business.Implementation.Services
{
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public EmailService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "kpi.acts.it81@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
             
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                
                #error Insert email here
                await client.AuthenticateAsync("email", "password");
                await client.SendAsync(emailMessage);
 
                await client.DisconnectAsync(true);
            }
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(UserRegistrationModel model)
        {
            var user = _mapper.Map<User>(model);
            
            return await _unit.UserManager.GenerateEmailConfirmationTokenAsync(user);
        }
    }
}