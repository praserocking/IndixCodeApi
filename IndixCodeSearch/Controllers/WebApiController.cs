using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using Indix.Models;
using IndixCodeSearch.Api;
using IndixCodeSearch.ApiDefinitions;

namespace IndixCodeSearch.Controllers
{
    public class WebApiController : ApiController
    {
        [Route("sample")]
        [HttpGet]
        public ApiResponse CounterSample()
        {
            IDataProcessor _processor = new DataProcessor();

            var y = _processor.ReturnParamListMappedToOccurence();

            string s = "",t="";
            foreach (var sample in y)
            {
                t += sample.Key + "\n";
                foreach (var ss in sample.Value)
                {
                    s += ss + "-";
                }
                s += "***\n\n";
            }
            return ApiResponse.CreateSuccessResponse(s);
        }
    }
}
