using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndixCodeSearch.Api
{
    interface IDataProcessor
    {
        /// <summary>
        /// Returns function names mapped to its occurences in files.
        /// </summary>
        /// <returns>a dictionary with function name as key and list of strings which are file names on which it occurs</returns>
        Dictionary<string, HashSet<string>> ReturnFunctionsNamesMappedToOccurences();

        /// <summary>
        /// Returns params lists mapped to its occurences in files
        /// </summary>
        /// <returns>a dictionary with params list as key and list of strings which are file names on which it occurs</returns>
        Dictionary<string, HashSet<String>> ReturnParamListMappedToOccurence();


    }
}
