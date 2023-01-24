using BL;
using Microsoft.AspNetCore.Identity;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using AlMohamyProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace AlMohamyProject.Controllers
{
    public class AccountRepository : IAccountRepository
    {
        SignInManager<ApplicationUser> SignInManager;
        UserManager<ApplicationUser> Usermanager;
        AlMohamyDbContext Ctx;
       
        public AccountRepository(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> usermanager, AlMohamyDbContext ctx)
        {
           
            Usermanager = usermanager;
            Ctx = ctx;
            SignInManager = signInManager;

        }

      



       



        public async Task<string> SignUpAsync(SignUpModel signUpModel)
        {

            if (signUpModel.PersonalImage != null)
            {
                string ImageName = Guid.NewGuid().ToString() + ".jpg";
                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                using (var stream = System.IO.File.Create(filePaths))
                {
                    await signUpModel.PersonalImage.CopyToAsync(stream);
                }
                signUpModel.ImageProfile = ImageName;
            }
            else
            {
                signUpModel.ImageProfile = "6bfaa416-900f-478b-a44d-984e099bd723.jpg";

            }

            var user = new ApplicationUser()
            {
               
                UserName = signUpModel.UserName,
                FirstName = signUpModel.FirstName,
                FamilyName = signUpModel.FamilyName,
                Email = signUpModel.Email,
                Image = signUpModel.ImageProfile,
                UserType = signUpModel.UserType
                



            };




            var r = await Usermanager.CreateAsync(user, signUpModel.Password);

            return r.ToString();
        }



        public async Task<string> LoginAsync(SignInModel signInModel)
        {
            var result = await SignInManager.PasswordSignInAsync(signInModel.UserName, signInModel.Password, true, true);


            return result.ToString();






        }


        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<ApplicationUser> ForgotPassword(ForgotPasswordViewModel model )
        {

            //if (user != null && await Usermanager.IsEmailConfirmedAsync(user))
            //{
            //    var token = await Usermanager.GeneratePasswordResetTokenAsync(user);
            //    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);
            //    logger.Log(LogLevel.Warning, passwordResetLink);
            //    return View("ForgotPasswordConfirmation");

            //}

            var user = await Usermanager.FindByNameAsync(model.UserName);

           
            if (user != null)
            {
                //await GenerateForgotPasswordTokenAsync(user, files);
            }





            return user;


        }




    }
}
