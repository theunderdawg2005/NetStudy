using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Models
{
    public class TaskDTO
    {
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
