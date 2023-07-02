using School.BusinessLogic.Interfaces;
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

namespace School.BusinessLogic
{
    public class CoursesService : ICourseService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public CoursesService(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration.GetConnectionString("School-APIDbConnection");
        }
        public Courses SelectCourseByID(int CourseId)
        {
            Courses courses = new Courses();
            try
            {
                string StoredProcedure = "SelectCourseById";
                //  string query = "  SELECT CoursesID,CoursesName,CoursesDescription FROM Courses WHERE CoursesId=@CoursesId";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    courses = SqlConn.QueryFirst<Courses>(StoredProcedure, new { @CoursesId = CourseId }, commandType: CommandType.StoredProcedure);
                }


            }
            catch
            {

            }
            return courses;
        }
        public  bool UpdateCourse(Courses course)
        {
            bool IsCourseUpdated = false;
            try
            {
                string StoredProcedure = "UpdateCourse";
              //  string queery = "UPDATE Courses SET CoursesName=@CourseName , CoursesDescription=@CoursesDescription WHERE CoursesID=@CourseID ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @CourseName = course.CoursesName, @CoursesDescription = course.CoursesDescription, @CourseID = course.CoursesID }, commandType: CommandType.StoredProcedure);
                    IsCourseUpdated = true;
                }
            }
            catch
            {
                IsCourseUpdated = false;
            }
            return IsCourseUpdated;
        }
        public  bool DeleteCourse(int CourseId)
        {
            bool ourseIsDeleted = false;
            int affectedRows = 0;

            try
            {
                string StoredProcedure = "DeleteCourse";
              //  string query = " delete StudentsCourses where CoursesID=@CoursesID delete CouresSubjects where CoursesID=@CoursesID delete TeachersCourses where CoursesID=@CoursesID delete Courses where CoursesID=@CoursesID";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    affectedRows = SqlConn.Execute(StoredProcedure, new { @CoursesID = CourseId }, commandType: CommandType.StoredProcedure);
                    //  affectedRows = SqlConn.Execute(query, new { @CoursesID = CourseId });
                    if (affectedRows != 0)
                    {
                        ourseIsDeleted = true;
                    }
                }

            }
            catch
            {
                if (affectedRows == 0)
                {
                    ourseIsDeleted = false;
                }
            }
            return ourseIsDeleted;







        }
        public  List<Courses> SelectAllCourses()
        {
            List<Courses> coursesList = new List<Courses>();
            try
            {
                string StoredProcedure = "SelectAllCourses";
              //  string query = "SELECT CoursesID,CoursesName,CoursesDescription FROM Courses";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    coursesList = SqlConn.Query<Courses>(StoredProcedure, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch 
            {
                return null;
            }
            return coursesList;


        } //select CoursesSubjectsID,CoursesID,SubjectsID from CouresSubjects where CoursesID=50


        public  bool SaveCourse(Courses course)
        {
            bool IsCountrySaved = false;
            string StoredProcedure = "SaveCourse";
         //   string query = "insert into Courses(CoursesName,CoursesDescription) values (@CoursesName,@CoursesDescription)";
            try
            {
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @CoursesName = course.CoursesName, @CoursesDescription = course.CoursesDescription }, commandType: CommandType.StoredProcedure);
                    IsCountrySaved = true;
                }
            }
            catch
            {
                IsCountrySaved = false;
            }
            return IsCountrySaved;
        }
        public  Courses SelectCourseByName(string CoursesName)
        {
            Courses courses = new Courses();
            try
            {
                string StoredProcedure = "SelectCourseByName";
              //  string query = "  SELECT CoursesID,CoursesName,CoursesDescription FROM Courses WHERE CoursesName=@CoursesName";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    courses = SqlConn.QueryFirst<Courses>(StoredProcedure, new { @CoursesName = CoursesName }, commandType: CommandType.StoredProcedure);
                }


            }
            catch
            {

            }
            return courses;
        }

    }
}
