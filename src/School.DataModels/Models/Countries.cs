using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class Countries
    {
        [Required]
        public int CountriesID { get; set; }
        [Required]
        [StringLength(2 )]
        public string ISO { get; set; }
        [Required]
        [StringLength(200)]
        public string CountryName { get; set; }
        [Required]
        public int PhoneCode { get; set; }
        [Required]
        [StringLength(3)]
        public string ISO3 { get; set; }
        [Required]
        public bool Deleted { get; set; }
    }

}
