using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class CoursesBL
    {
        /*
        public int CoursesID { get; set; }
        public string CoursesName { get; set; }
        public string CoursesDescription { get; set; }
        public bool Deleted { get; set; }
        */
        public string Message { get; set; }
        public string Status { get; set; }
    }
    public class CoursesBL<T>:CoursesBL
    {
        public T Data { get; set; }
    }
}
