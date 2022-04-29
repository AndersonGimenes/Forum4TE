using Forum4TE.Domain.Interfaces;
using Forum4TE.Security;
using Forum4TE.UI.Mapper;
using Forum4TE.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Forum4TE.UI.Controllers
{
    public class ForumController : BaseController
    {
        private readonly IContentService _service;

        public ForumController(IContentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var models = MapperModel.MapperContentToContentModelList(_service.GetAll());
            return View(models);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return LoginValidate(() => View());
        }
        
        [HttpPost]
        public IActionResult Create(ContentModel model)
        {
            return ExecuteWithLoginValidate(() =>
            {
                GetCookieUser();
                var content = MapperModel.MapperContentModelToContent(model).SetUserId(Guid.Parse(UserToken.UserId));

                _service.Create(content);
            });
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            return LoginValidate(() => View(MapperModel.MapperContentToContentModel(_service.Get(id))));
        }

        [HttpPost]
        public IActionResult Update(ContentModel model)
        {
            return ExecuteWithLoginValidate(() => 
            {
                GetCookieUser();
                var content = MapperModel.MapperContentModelToContent(model).SetUserId(Guid.Parse(UserToken.UserId));

                _service.Update(content);
            });
        }

        [HttpGet]
        public IActionResult UpdateList()
        {
            return LoginValidate(() =>
            {
                GetCookieUser();                
                var models = MapperModel.MapperContentToContentModelList(_service.GetAllByUser(Guid.Parse(UserToken.UserId)));

                return View(models);
            });
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return LoginValidate(() => Execute(() => _service.Delete(id)));
        }
    }
}
