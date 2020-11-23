using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;

namespace EServicesWithAngular.DAL.Helper
{
    public class Handler
    {
        public static String HandleCultureName(HttpContext currentContext = null)
        {
            string cookieLanguage = currentContext == null ? null : CookiesHandler.GetLanguageFromCookie(currentContext);

            if (cookieLanguage == "Arabic")
                SetLanguageToAr(currentContext);
            else if (cookieLanguage == "English")
                SetLanguageToEn(currentContext);

            return Thread.CurrentThread.CurrentUICulture.TextInfo.CultureName.Split(new char[] { '-' })[0];
        }

        public static void SetLanguageToAr(HttpContext currentContext)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-SA");
            if (CookiesHandler.GetLanguageFromCookie(currentContext) != "Arabic")
                CookiesHandler.UpdateLanguageCookie(currentContext, "Arabic");
        }

        public static void SetLanguageToEn(HttpContext currentContext)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            if (CookiesHandler.GetLanguageFromCookie(currentContext) != "English")
                CookiesHandler.UpdateLanguageCookie(currentContext, "English");
        }

      

        //public static string ConvertGregorianToHijri(DateTime toBeConverted)
        //{
        //    DateTimeFormatInfo DTFormat;
        //    DTFormat = new CultureInfo("ar-sa", false).DateTimeFormat;
        //    DTFormat.Calendar = new UmAlQuraCalendar();
        //    DTFormat.ShortDatePattern = "yyyy-MM-dd";
        //    CultureInfo esES = new CultureInfo("es-ES");
        //    DateTime GregorianDate;

        //    GregorianDate = Convert.ToDateTime(toBeConverted, esES);
        //    return GregorianDate.Date.ToString("d", DTFormat);
        //}

    }
}