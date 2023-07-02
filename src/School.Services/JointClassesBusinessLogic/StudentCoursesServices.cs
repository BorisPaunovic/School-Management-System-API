using School.Services.Interfaces.IJointClassesBusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using Microsoft.Extensions.Configuration;
using School.DataModels.Models;

namespace School.Services.JointClassesBusinessLogic
{
    public class StudentCoursesServices:IStudentCoursesServices
    {


        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public StudentCoursesServices(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration.GetConnectionString("School-APIDbConnection");
        }


        public bool AddStudentCourse(StudentCourses studentCourses)
        {
            bool IsStudentCourseIserted = false;
            try
            {
                string StoredProcedure = "AddStudentCourse";
               // string query = "INSERT INTO StudentsCourses(StudentsID,CoursesID,StartDate) VALUES(@StudentId,@CourseId,@Startdate)";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @StudentId = studentCourses.StudentsID, @CourseId = studentCourses.CoursesID , @Startdate = studentCourses.StartDate }, commandType: CommandType.StoredProcedure);
                    IsStudentCourseIserted = true;
                }

            }
            catch
            {
                IsStudentCourseIserted = false;
            }
            return IsStudentCourseIserted;
        }
        public  bool UpdateStudentCourse(StudentCourses studentCourses)
        {
            bool IsStudentCourseUpdated = false;
            try
            {
               string StoredProcedure = "UpdateStudentCourseNew";
             //   string queery = "UPDATE StudentsCourses SET CoursesID=@CoursesID,Passed=@Passed,StudentsID=@StudentsID WHERE StudentsCoursesID= @StudentsCoursesID";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @StudentsID = studentCourses.StudentsID, @CoursesID = studentCourses.CoursesID, @Passed = studentCourses.Passed, @StudentsCoursesID =studentCourses.StudentsCoursesID}, commandType: CommandType.StoredProcedure);
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
