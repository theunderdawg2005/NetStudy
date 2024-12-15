using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Models
{
    public class Question
    {
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
        [Required]
        public string Owner { get; set; }
    }
}
