using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS370.PropertyHub.WebUI.Common
{
    public static class WebUtil
    {

        public static readonly string CURRENT_USER="CurrentUser";
        public static readonly int ADMIN_ROLE = 1;
        public static readonly string USER_COOKIE = "User370";


        public static void Set<T>(this ISession session,string key,T value)
        {
            string jsonData = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonData);
        }

        public static T Get<T>(this ISession session, string key)
        {
            string jsonData =session.GetString(key);
            if (string.IsNullOrWhiteSpace(jsonData)) return default;
            T u = JsonConvert.DeserializeObject<T>(jsonData);
            return u;
        }
    }
}
