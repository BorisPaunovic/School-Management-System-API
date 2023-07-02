using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface ICountriesService
    {


        public Countries SelectCountryByID(int CountryID);

        public Countries SelectCountryByName(string CountryName);

        public List<Countries> SelectAllCountryes();

        public bool SaveCountry(Countries country);

        public bool DeleteCountry(int CountryId);

        public bool UpdateCountry(Countries countries);
       
    }
}
