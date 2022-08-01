using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Constants
{
    /// <summary>
    /// Use to store a set of application values that will not change
    /// </summary>
    public static class AppSettings
    {
        public const string API_URL = "https://api.punkapi.com/v2/";
        public static string? FILE_PATH = Environment.GetEnvironmentVariable("JsonFilePath");
    }
}
