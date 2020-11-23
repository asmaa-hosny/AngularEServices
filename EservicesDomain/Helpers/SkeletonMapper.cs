using CommonLibrary.Configuaration;
using EServicesCommon.DI;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace EservicesDomain.Helpers
{
    public class SkeletonMapper
    {

        public static string MapObjectToSkeleton(IMap maps, bool forJavaScript = false, bool forHTML = false, string usedQuotesType = "'")
        {
            
            var hostingEnvironemnt = FactoryManager.Instance.Resolve<IHostingEnvironment>();
            var config = FactoryManager.Instance.Resolve<ICoreConfigurations>();
            StringBuilder file = new StringBuilder();
            var path = Path.Combine(hostingEnvironemnt.WebRootPath+"\\" + config.SkeletonFolder +"\\"+ maps.getFileName());
            var fileStreamReader = new System.IO.StreamReader(path);
            string line;
            while ((line = fileStreamReader.ReadLine()) != null)
            {
                file.Append(line);
                if (!forHTML)
                    file.Append(@"\n");
            }

            PropertyInfo[] props = maps.GetType().GetProperties();

            if (forJavaScript)
            {
                foreach (PropertyInfo prop in props)
                {
                    file.Replace(String.Format("[{0}]", prop.Name), String.Format("{0}+$('#{1}').val()+{0}", usedQuotesType, prop.GetValue(maps, null).ToString()));
                }
            }
            else
            {
                foreach (PropertyInfo prop in props)
                {
                    file.Replace(String.Format("[{0}]", prop.Name), prop.GetValue(maps, null)?.ToString());
                }
            }

            return forHTML ? file.ToString() : file.ToString().Replace("&", "\\&").Replace("\"", "\\\"");
        }
    }
}
