using System.Collections.Generic;
using System.IO;
using System.Web;
using IndixCodeSearch.Api;

namespace IndixCodeSearch.ApiDefinitions
{
    public class DataReader : IDataReader
    {
        private static readonly string _basePath = HttpContext.Current.Server.MapPath("~/App_Data/src");

        public Dictionary<string, string> ReadAllSourceFiles()
        {
            Dictionary<string,string> fileToContentMap = new Dictionary<string, string>();
            foreach (var file in Directory.EnumerateFiles(_basePath))
            {
                fileToContentMap.Add(file,File.ReadAllText(file));
            }
            return fileToContentMap;
        }
    }
}