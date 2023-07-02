using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class TeachersCoursesBL
    {
        /*
        public int TeachersCoursesId { get; set; }
        public int TeachersId { get; set; }
        public int CoursesId { get; set; }
        */
        public string Message { get; set; }
        public string Stastus { get; set; }
    }

    public class TeachersCoursesBL<T> : TeachersCoursesBL
    {
        public T Data { get; set; }
    }
}
