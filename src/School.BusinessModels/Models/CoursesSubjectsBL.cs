using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class CoursesSubjectsBL
    {
        /*
        public int CoursesSubjectsId { get; set; }
        public int CoursesId { get; set; }
        public int SubjectsId { get; set; }
        */
        public string Message { get; set; }
        public string Status { get; set; }

    }
    public class CoursesSubjectsBL<T> : CoursesSubjectsBL
    {
        public T Data { get; set; }
    }
}
