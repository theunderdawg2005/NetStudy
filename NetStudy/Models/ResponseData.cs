using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Models
{
    public class ResponseData
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("response")]  
        public string Response { get; set; }
    }
}
