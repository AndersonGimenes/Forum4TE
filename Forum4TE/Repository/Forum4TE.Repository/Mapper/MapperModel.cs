using Forum4TE.Domain.Entites;
using Forum4TE.Repository.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Forum4TE.Repository.Mapper
{
    internal static class MapperModel
    {
        public static IEnumerable<ContentDomain> MapperContentModelToContentList(IEnumerable<ContentModel> models)
        {
            var resultList = new List<ContentDomain>();

            foreach (var model in models)
            {
                var creator = model.User.FullName;
                model.User = null;

                resultList.Add(MapperContentModelToContent(model).SetCreator(creator));
            }

            return resultList;
        }

        public static ContentModel MapperContentToContentModel(ContentDomain content)
        {
            var json = JsonConvert.SerializeObject(content);
            return JsonConvert.DeserializeObject<ContentModel>(json);
        }

        public static ContentDomain MapperContentModelToContent(ContentModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            return JsonConvert.DeserializeObject<ContentDomain>(json);
        }

        public static UserModel MapperUserToUserModel(UserDomain user)
        {
            var json = JsonConvert.SerializeObject(user);
            return JsonConvert.DeserializeObject<UserModel>(json);
        }

        public static UserDomain MapperUserModelToUser(UserModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            return JsonConvert.DeserializeObject<UserDomain>(json);
        }
    }
}
