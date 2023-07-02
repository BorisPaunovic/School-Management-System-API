using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class Students
    {
        public int StudentsID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }
        public int CountriesID { get; set; }
        public bool Deleted { get; set; }

    }
}
