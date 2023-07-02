using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class TeachersJoinCoursesResault
    {
        public int TeachersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }
        public int TeachersCoursesId { get; set; }

        public int CoursesId { get; set; }
        public string CoursesName { get; set; }
        public string CoursesDescription { get; set; }

    }
}
