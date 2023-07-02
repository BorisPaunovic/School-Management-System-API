using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class CoursesSubjects
    {
        public int CoursesSubjectsId { get; set; }
        public int CoursesId { get; set; }
        public int SubjectsId { get; set; }
    }
}
