using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class StudentCoursesBL
    {
        /*
        public int StudentsCoursesID { get; set; }
        public int StudentsID { get; set; }
        public int CoursesID { get; set; }
        public bool Passed { get; set; }
        public DateTime StartDate { get; set; }
        */
        public string Message { get; set; }
        public string Status { get; set; }

    }
    public class StudentCoursesBL<T> : StudentCoursesBL
    {
        public T Data { get; set; }
    }

}
