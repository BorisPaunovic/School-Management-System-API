using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using School.Services.Interfaces.IJointClassesBusinessLogic;
using School.DataModels.Models;

namespace School.Services.JointClassesBusinessLogic
{
    public class TeacherCoursesServices: ITeacherCoursesServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public TeacherCoursesServices(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration.GetConnectionString("School-APIDbConnection");
        }

        public  bool AddTeacherCourses(TeachersCourses teachersCourses)
        {
            bool IsCourseSubjectInserted = false;
            try
            {
                string StoredProcedure = "AddTeacherCourses";
              //  string query = "insert into TeachersCourses(TeachersID,CoursesID) values(@TeachersID,@CoursesID)";

                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @TeachersID = teachersCourses. TeachersId, @CoursesID = teachersCourses.CoursesId }, commandType: CommandType.StoredProcedure);
                    IsCourseSubjectInserted = true;
                }

            }
            catch
            {
                IsCourseSubjectInserted = false;
            }
            return IsCourseSubjectInserted;
        }
        public  bool UpdateTeachersCourses(TeachersCourses teachersCourses)
        {
            bool IsStudentCourseUpdated = false;
            try
            {
                string StoredProcedure = "UpdateTeachersCourses";
               // string queery = "update TeachersCourses set CoursesID=@CoursesId where TeachersCoursesID=@TeachersCoursesId and TeachersID=@TeachersId ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @CoursesId = teachersCourses. CoursesId, @TeachersId = teachersCourses.TeachersId, @TeachersCoursesId = teachersCourses.TeachersCoursesId }, commandType: CommandType.StoredProcedure);
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
