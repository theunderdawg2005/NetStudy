using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Models
{
    public class GroupMessage
    {
        public string Id { get; set; }
        public string Sender { get; set; }
        public string GroupId { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
