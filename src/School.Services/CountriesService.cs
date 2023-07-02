using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using Microsoft.Extensions.Configuration;
using School.Services.Interfaces;

namespace School.Services
{
    public  class CountriesService:ICountriesService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public CountriesService(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration.GetConnectionString("School-APIDbConnection");
        }

        public  Countries SelectCountryByID(int ID)
        {
            Countries countries = new Countries();
            try
            {
                string StoredProcedure = "SelectCountryByID";
              //  string query = "  select CountriesID from CountriesBL where CountryName = @CountryName";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    countries = SqlConn.QueryFirst<Countries>(StoredProcedure, new { @ID =ID }, commandType: CommandType.StoredProcedure);
                }


            }
            catch
            {

            }
            return countries;
        }
        public  Countries SelectCountryByName(string CountryName)
        {
            Countries countries = new Countries();
            try
            {
                string StoredProcedure = "SelectCountryByName";

             //   string query = "  select CountriesID,ISO,CountryName,PhoneCode,ISO3,Deleted from CountriesBL where CountryName = @CountryName";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    countries = SqlConn.QueryFirst<Countries>(StoredProcedure, new { @CountryName = CountryName }, commandType: CommandType.StoredProcedure);
                    //  countries = SqlConn.QueryFirst<CountriesBL>(query, new { @CountryName = CountryName });
                }


            }
            catch
            {

            }
            return countries;
        }
        public  List<Countries> SelectAllCountryes()
        {
            List<Countries> countries = new List<Countries>();
            try
            {
                string StoredProcedure = "SelectAllCountryes";
              //  string query = "   select countriesid,CountryName,ISO,iso3,PhoneCode,Deleted from CountriesBL ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    countries = SqlConn.Query<Countries>(StoredProcedure, commandType: CommandType.StoredProcedure).ToList();
                }


            }
            catch
            {

            }
            return countries;
        }
        public  bool SaveCountry(Countries country)
        {
            bool IsCountrySaved = false;
            string StoredProcedure = "SaveCountry";
           // string query = "insert into CountriesBL(ISO,CountryName,PhoneCode,ISO3)values(@ISO,@CountryName,@PhoneCode,@ISO3)";
            try
            {
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @ISO = country.ISO, @CountryName = country.CountryName, @PhoneCode = country.PhoneCode, @ISO3 = country.ISO3 }, commandType: CommandType.StoredProcedure);
                    IsCountrySaved = true;
                }
            }
            catch
            {
                IsCountrySaved = false;
            }
            return IsCountrySaved;
        }
        public  bool DeleteCountry(int CountryId)
        {
            bool CountryIsDeleted = false;
            int affectedRows = 0;

            try
            {
                string StoredProcedure = "DeleteCountry";
              //  string query = "update StudentsBL set CountriesID = null where CountriesID=@CountryId delete from CountriesBL where CountriesID=@CountryId";
              //  string query1 = " UPDATE CountriesBL SET Deleted = 1 WHERE CountriesID = @CountryId";


                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    affectedRows = SqlConn.Execute(StoredProcedure, new { @CountryId = CountryId }, commandType: CommandType.StoredProcedure);
                    //  affectedRows = SqlConn.Execute(query1, new { @CountryId = CountryId });
                    if (affectedRows != 0)
                    {
                        CountryIsDeleted = true;
                    }
                }

            }
            catch
            {
                if (affectedRows == 0)
                {
                    CountryIsDeleted = false;
                }
            }
            return CountryIsDeleted;







        }
        public  bool UpdateCountry( Countries countries)
        {

            bool IsStudentCourseUpdated = false;
            try
            {
                string StoredProcedure = "UpdateCountry";
              //  string queery = "UPDATE CountriesBL SET CountryName = @CountryName, ISO = @ISO,ISO3 = @ISO3, PhoneCode = @PhoneCode WHERE CountriesID = @CountriesID ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @CountryName = countries.CountryName, @ISO = countries.ISO, @ISO3 = countries.ISO3, @PhoneCode = countries. PhoneCode, @CountriesID = countries.CountriesID }, commandType: CommandType.StoredProcedure);
                    IsStudentCourseUpdated = true;
                }
            }
            catch
            {
                IsStudentCourseUpdated = false;
            }
            return IsStudentCourseUpdated;
        }
    }
}


