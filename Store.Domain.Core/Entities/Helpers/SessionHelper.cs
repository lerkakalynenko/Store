using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Extensions;
namespace Store.Domain.Core.Entities.Helpers
{
    public static class SessionHelper
    {
        public static void SetSessionString<T>(this ISession session, string key, T value)
        {
            var jsonValue = JsonConvert.SerializeObject(value);

            session.SetString(key, jsonValue);
        }

        public static T GetSessionString<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}