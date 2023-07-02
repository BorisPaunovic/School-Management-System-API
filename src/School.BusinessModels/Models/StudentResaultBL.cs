using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
   
        public class StudentsResaultBL
        {
          /*
            public int StudentsID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Adress { get; set; }
            public string CoursesName { get; set; }
            public bool Passed { get; set; }
            public DateTime StartDate { get; set; }
            public string CoursesDescription { get; set; }
            public string CountryName { get; set; }
          */
          public string Message { get; set; }
            public string Status { get; set; }

        }
        public class StudentsResaultBL<T>:StudentsResaultBL
        {
            public T Data { get; set; }
        }
    
}
