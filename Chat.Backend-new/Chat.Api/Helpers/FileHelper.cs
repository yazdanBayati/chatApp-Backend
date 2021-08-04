using System.IO;
using System.Reflection;
using Chat.Api;
using Microsoft.Extensions.PlatformAbstractions;

namespace Chat.Api.Helpers
{
    public class FileHelper
    {
        public static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
