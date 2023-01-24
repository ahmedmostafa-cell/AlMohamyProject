using AlMohamyProject.Models;
using BL;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AlMohamyProject.Controllers
{
    public interface IAccountRepository
    {
      

      

        Task<string> SignUpAsync(SignUpModel signUpModel);

        Task<string> LoginAsync(SignInModel signInModel);

        Task<ApplicationUser> ForgotPassword(ForgotPasswordViewModel model);

    }
}
