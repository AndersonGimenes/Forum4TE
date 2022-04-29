using Forum4TE.Domain.Entites;
using Forum4TE.Domain.Interfaces;
using Forum4TE.Security;
using Forum4TE.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Forum4TE.UI.Controllers
{
    public abstract class BaseController : Controller
    {   
        protected static string ErrorMessage;
        
        [HttpGet]
        public IActionResult Error() => View(new ErrorModel { ErrorMessage = ErrorMessage });

        public IActionResult Execute(Action action)
        {
            try
            {
                action.Invoke();

                return RedirectToAction("Get", "Forum");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;

                return RedirectToAction("Error");
            }
        }

        public IActionResult ExecuteWithLoginValidate(Action action)
        {
            try
            {
                return LoginValidate(() =>
                {
                    action.Invoke();

                    return RedirectToAction("Get", "Forum");
                });
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;

                return RedirectToAction("Error");
            }
        }

        public IActionResult LoginValidate(Func<IActionResult> action)
        {
            ErrorMessage = "Unauthorized";

            if (!Request.Cookies.TryGetValue("token", out string _))
                return RedirectToAction("Error");
            
            GetCookieUser();

            Guid.TryParse(UserToken.UserId, out Guid userId);

            if(userId == default)
                return RedirectToAction("Error");

            ErrorMessage = default;

            return action.Invoke();
        }
                
        protected void SetCookieUser(UserDomain user)
        {            
            var tokenEncript = TokenHandler.EncryptToken($"{user.Id},{user.FullName}");

            Response.Cookies.Append("token", tokenEncript);

            UserToken.UserName = user.FullName;
            UserToken.IsLoged = true;
        }

        protected void GetCookieUser()
        {
            Request.Cookies.TryGetValue("token", out string token);

            if (token != null)
            {
                var result = TokenHandler.DecryptToken(token);

                UserToken.UserId = result[0];
                UserToken.UserName = result[1];
            }
        }

        protected void DeleteCookieUser()
        {
            Response.Cookies.Delete("token");

            UserToken.UserName = default;
            UserToken.UserId = default;
            UserToken.IsLoged = default;
        }
    }
}
