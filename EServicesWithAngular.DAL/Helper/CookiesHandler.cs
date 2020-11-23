using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.DAL.Helper
{
    public class CookiesHandler
    {
        private static string KTACookieName = "KTA Session";
        private static string Language = "Language";

        public static string GetKTASession(HttpContext context)
        {
            return context.Request.Cookies[KTACookieName];         
        }

        public static void UpdateKTASession(HttpContext context, string session)
        {
            CookieOptions option = new CookieOptions();
            context.Response.Cookies.Delete(KTACookieName);
            option.Expires = DateTime.Now.AddMinutes(30);
            context.Response.Cookies.Append(KTACookieName, session, option);
            //context.Request.HttpContext.Items[KTACookieName] = session;
        }


        public static string GetLanguageFromCookie(HttpContext context)
        {
            return context.Request.Cookies[Language];
        }

        public static void UpdateLanguageCookie(HttpContext context, string lang)
        {
            CookieOptions option = new CookieOptions();
            context.Response.Cookies.Delete(Language);
            option.Expires = DateTime.Now.AddMinutes(30);
            context.Response.Cookies.Append(KTACookieName, lang, option);
        }
    }
}