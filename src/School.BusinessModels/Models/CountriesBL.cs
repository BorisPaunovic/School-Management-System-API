using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class CountriesBL
    {
        /*
        public int CountriesID { get; set; }
        public string ISO { get; set; }
        public string CountryName { get; set; }
        public int PhoneCode { get; set; }
        public string ISO3 { get; set; }
        public bool Deleted { get; set; }
        */

       public string Message { get; set; }
        public string Status { get; set; }
    }
    public class CountriesBL<T> : CountriesBL
    {
        public T Data { get; set; }
    }

}
