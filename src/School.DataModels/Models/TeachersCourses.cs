using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class TeachersCourses
    {
        public int TeachersCoursesId { get; set; }
        public int TeachersId { get; set; }
        public int CoursesId { get; set; }
    }
}
