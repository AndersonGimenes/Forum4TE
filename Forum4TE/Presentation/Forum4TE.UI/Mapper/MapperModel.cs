using Forum4TE.Domain.Entites;
using Forum4TE.UI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Forum4TE.UI.Mapper
{
    internal static class MapperModel
    {
        public static IEnumerable<ContentModel> MapperContentToContentModelList(IEnumerable<ContentDomain> contents)
        {
            var resultList = new List<ContentModel>();

            foreach (var content in contents)
                resultList.Add(MapperContentToContentModel(content));

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

        public static UserDomain MapperUserModelToUser(UserModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            return JsonConvert.DeserializeObject<UserDomain>(json);
        }
    }
}
