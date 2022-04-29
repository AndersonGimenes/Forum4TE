using Forum4TE.Domain.Interfaces;
using Forum4TE.UI.Mapper;
using Forum4TE.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum4TE.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUserService _service;
        
        public LoginController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel model)
        {
            return Execute(() =>
            {
                var user = _service.GetByCredential(model.Email, model.Password);

                SetCookieUser(user);
            });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            DeleteCookieUser();

            return RedirectToAction("Get", "Forum");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            return Execute(() =>
            {
                var user = MapperModel.MapperUserModelToUser(model);

                _service.Create(user);
            });
        }
    }
}
