using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Models
{
    public class UploadResponse
    {
        public string DocumentId { get; set; }
        public string UploaderName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public bool ShareWithFriends { get; set; }
        public bool ShareWithGroups { get; set; }
        public bool ShareWithAll { get; set; }
    }
}
