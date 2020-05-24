using System.Threading.Tasks;
using Business.Models;

namespace Business.Abstraction
{
    public interface IUserService
    {
        Task<string> Register(UserRegistrationModel model);
    }
}