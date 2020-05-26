using System.Threading.Tasks;
using Business.Models;
using Data.Entities;

namespace Business.Abstraction
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task<string> GenerateEmailConfirmationTokenAsync(UserRegistrationModel model);
    }
}