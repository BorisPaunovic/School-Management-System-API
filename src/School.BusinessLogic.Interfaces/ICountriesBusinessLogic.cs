using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces
{
    public interface ICountriesBusinessLogic
    {
        #region Countries Functions
        public Countries SelectCountryByName(string CountryName);



        public Countries SelectCountryByID(int CountryId);


        public bool SaveCountry(Countries country);


        public bool ValidateCountry(bool IsIsovalid, bool IsIso3Valid, bool IsPhoneCodeValid, bool IsCountryNamevalid);


        public bool ValidateISO(string iso);


        public bool ValidateISO3(string iso3);


        public bool ValidatePhoneCode(int PhoneCode);



        public bool ValidateCountryName2(string CountryName);



        public bool ValidateCountryName(string CountryName);


        public List<Countries> SelectAllCountryes();


        public bool DeleteCountry(int CountryId);


        public bool UpdateCountry(Countries countries);


        public List<Countries> FilterByCountryName(List<Countries> countries, string TextBox);


        public List<Countries> FilterByIso(List<Countries> countries, string TextBox);
        #endregion



        #region CountriesBL Functions
        public CountriesBL SelectCountryBLByName(string CountryName);



        public CountriesBL SelectCountryBLByID(int CountryId);


        public bool SaveCountryBL(CountriesBL<Countries> country);


       


        public List<CountriesBL<Countries>> SelectAllCountryesBL();


        public bool DeleteCountryBL(int CountryId);


        public bool UpdateCountryBL(CountriesBL<Countries> country);


        public List<CountriesBL<Countries>> FilterByCountryNameBL(List<CountriesBL<Countries>> countries, string TextBox);


        public List<CountriesBL<Countries>> FilterByIsoBL(List<CountriesBL<Countries>> countries, string TextBox);
        #endregion

    }
}
