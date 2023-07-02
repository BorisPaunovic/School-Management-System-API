using AutoMapper;
using Microsoft.AspNetCore.Http;
using School.BusinessLogic.Interfaces;
using School.DataModels.Models;
using School.Services;
using School.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace School.BusinessLogic
{
    public class CountriesBusinessLogic:ICountriesBusinessLogic
    {
        private readonly ICountriesService _countriesService;
        private readonly IMapper _mapper;

        
        public CountriesBusinessLogic(ICountriesService countriesService,IMapper mapper) 
        {
            this._countriesService = countriesService;
            this._mapper = mapper;
        }
        #region Countries Region
        public Countries SelectCountryByName(string CountryName)
        {
            Countries countries = new Countries();
            countries = _countriesService.SelectCountryByName(CountryName);
            return countries;
        }

        public Countries SelectCountryByID (int CountryId)
        {
            Countries countries = new Countries();
            countries = _countriesService.SelectCountryByID(CountryId);
            return countries;
        }
        public bool SaveCountry(Countries country)
        {
            bool IsCountrySaved = _countriesService.SaveCountry(country);
            return IsCountrySaved;
        }
        public bool ValidateCountry(bool IsIsovalid, bool IsIso3Valid, bool IsPhoneCodeValid, bool IsCountryNamevalid)
        {
            bool IsCountryValid = false;

            if (IsIsovalid == true && IsIso3Valid == true && IsPhoneCodeValid == true && IsCountryNamevalid == true)
            {
                IsCountryValid = true;
            }
            else
            {
                IsCountryNamevalid = false;
            }
            return IsCountryValid;
        }
        public bool ValidateISO(string iso)
        {
            bool IsISOValid = false;
            if (String.IsNullOrEmpty(iso) == false && iso.Length == 2)
            {
                IsISOValid = true;
            }
            else
            {
                IsISOValid = false;
            }
            return IsISOValid;

        }
        public bool ValidateISO3(string iso3)
        {
            bool IsIso3Valid = false;
            if (String.IsNullOrEmpty(iso3) == false && iso3.Length == 3)
            {
                IsIso3Valid = true;
            }
            else
            {
                IsIso3Valid = false;
            }
            return IsIso3Valid;
        }
        public bool ValidatePhoneCode(int PhoneCode)
        {
            bool IsPhoneCodeValid = false;
            if (String.IsNullOrEmpty(PhoneCode.ToString()) == false)
            {
                IsPhoneCodeValid = true;
            }
            else
            {
                IsPhoneCodeValid = false;
            }
            return IsPhoneCodeValid;
        }

        public bool ValidateCountryName2(string CountryName)
        {

            bool IsCountryNameValid = false;
            if (String.IsNullOrEmpty(CountryName) == false && CountryName.Length > 3)
            {
                IsCountryNameValid = true;
            }
            else
            {
                IsCountryNameValid = false;
            }

            return IsCountryNameValid;
        }

        public bool ValidateCountryName(string CountryName)
        {
            var a = SelectCountryByName(CountryName).CountryName;
            bool IsUnique = String.IsNullOrEmpty(SelectCountryByName(CountryName).CountryName);
            bool IsCountryNameValid = false;
            if (String.IsNullOrEmpty(CountryName) == false && IsUnique == true && CountryName.Length > 3)
            {
                IsCountryNameValid = true;
            }
            else
            {
                IsCountryNameValid = false;
            }

            return IsCountryNameValid;
        }
        public List<Countries> SelectAllCountryes()
        {
            List<Countries> countries = new List<Countries>();
            countries = _countriesService.SelectAllCountryes();
          
            return countries;
        }
        public bool DeleteCountry(int CountryId)
        {
            bool CountryIsDeleted = _countriesService.DeleteCountry(CountryId);
            return CountryIsDeleted;
        }
        public bool UpdateCountry(Countries country)
        {
            bool IsCountryUpdated = false;
            IsCountryUpdated = _countriesService.UpdateCountry(country);
            return IsCountryUpdated;

        }
        public List<Countries> FilterByCountryName(List<Countries> countries, string TextBox)
        {

            List<Countries> countries1 = new List<Countries>();
            foreach (var element in countries)
            {
                if (element.CountryName.ToLower().Contains(TextBox.ToLower()) == true)
                {
                    countries1.Add(element);
                }


            }
            return countries1;

        }
        public List<Countries> FilterByIso(List<Countries> countries, string TextBox)
        {

            List<Countries> countries1 = new List<Countries>();
            foreach (var element in countries)
            {
                if (element.ISO.ToLower().Contains(TextBox.ToLower()) == true)
                {
                    countries1.Add(element);
                }


            }
            return countries1;

        }


        #endregion

        #region CountriesBL Region
        public CountriesBL SelectCountryBLByName(string CountryName)
        {
            Countries countries = new Countries();
            countries = _countriesService.SelectCountryByName(CountryName);
            var countryBL = _mapper.Map<CountriesBL<Countries>>(countries);
            if (countryBL.Data == null)
            {
                countryBL.Status = StatusCodes.Status500InternalServerError.ToString();
                countryBL.Message = "Error";
            }
            else
            {
                countryBL.Status = StatusCodes.Status200OK.ToString();
                countryBL.Message = "Sucsess";
            }
            return countryBL;
        }

        public CountriesBL SelectCountryBLByID(int CountryId)
        {
            Countries countries = new Countries();
            countries = _countriesService.SelectCountryByID(CountryId);
            var countryBL = _mapper.Map<CountriesBL<Countries>>(countries);
            if (countryBL.Data == null)
            {
                countryBL.Status = StatusCodes.Status500InternalServerError.ToString();
                countryBL.Message = "Error";
            }
            else
            {
                countryBL.Status = StatusCodes.Status200OK.ToString();
                countryBL.Message = "Sucsess";
            }
            return countryBL;
        }

        public bool SaveCountryBL(CountriesBL<Countries> countryBL)
        {
            var country = _mapper.Map<Countries>(countryBL);

            bool IsCountrySaved = SaveCountry(country);
           
            return IsCountrySaved;
        }

        

        public List<CountriesBL<Countries>> SelectAllCountryesBL()
        {
            
            var countries = SelectAllCountryes();
            var countriesBL = _mapper.Map<List<CountriesBL<Countries>>>(countries);
            
                foreach (var element in countriesBL)
                {
                   if (countriesBL.FirstOrDefault().Data == null)
                   {
                    element.Status =  StatusCodes.Status500InternalServerError .ToString();
                    element.Message = "Error";
                   }
                   else
                   {
                    element.Status = StatusCodes.Status200OK.ToString();
                    element.Message = "Sucsess";
                }
                 }
            return countriesBL;

        }

        public bool DeleteCountryBL(int CountryId)
        {
           

            bool IsCountrySaved = DeleteCountry(CountryId);

            return IsCountrySaved;
        }

        public bool UpdateCountryBL(CountriesBL<Countries> countriesBl)
        {
            var country = _mapper.Map<Countries>(countriesBl);

            bool IsCountrySaved = UpdateCountry(country);

            return IsCountrySaved;
        }

        public List<CountriesBL<Countries>> FilterByCountryNameBL(List<CountriesBL<Countries>> countries, string TextBox)
        {
            List<CountriesBL<Countries>> countries1 = new List<CountriesBL<Countries>>();
            foreach (var element in countries)
            {
                if (element.Data.CountryName.ToLower().Contains(TextBox.ToLower()) == true)
                {
                    countries1.Add(element);
                }


            }
            return countries1;
        }

        public List<CountriesBL<Countries>> FilterByIsoBL(List<CountriesBL<Countries>> countries, string TextBox)
        {

            List<CountriesBL<Countries>> countries1 = new List<CountriesBL<Countries>>();
            foreach (var element in countries)
            {
                if (element.Data.ISO.ToLower().Contains(TextBox.ToLower()) == true)
                {
                    countries1.Add(element);
                }


            }
            return countries1;
        }
        #endregion



    }
}
