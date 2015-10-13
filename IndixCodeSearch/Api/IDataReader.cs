using System.Collections.Generic;

namespace IndixCodeSearch.Api
{
    interface IDataReader
    {
        /// <summary>
        /// Reads tht files under App_Data/src directory and makes a map of content with filename.
        /// </summary>
        /// <returns>Dictionary of filenames mapped to content</returns>
        Dictionary<string, string> ReadAllSourceFiles();
    }
}
