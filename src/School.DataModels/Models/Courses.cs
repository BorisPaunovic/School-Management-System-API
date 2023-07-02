using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class Courses
    {
        [Required]
        public int CoursesID { get; set; }
        [Required ]
        [StringLength(100) ]
        public string CoursesName { get; set; }
        [Required]
        [StringLength(500)]
        public string CoursesDescription { get; set; }
        [Required]
        public bool Deleted { get; set; }
    }
}
