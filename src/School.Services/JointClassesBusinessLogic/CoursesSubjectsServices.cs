using Microsoft.Extensions.Configuration;
using School.DataModels.Models;
using School.Services.Interfaces.IJointClassesBusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace School.Services.JointClassesBusinessLogic
{
    public class CoursesSubjectsServices: ICoursesSubjectsServices
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public CoursesSubjectsServices(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration.GetConnectionString("School-APIDbConnection");
        }

        public  List<CoursesSubjects> SelectAllCoursesSubjects()
        {
            List<CoursesSubjects> coursesList = new List<CoursesSubjects>();
            try
            {
                string StoredProcedure = "SelectAllCoursesSubjects";
              //  string query = "select CoursesSubjectsID,CoursesID,SubjectsID from CouresSubjects";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    coursesList = SqlConn.Query<CoursesSubjects>(StoredProcedure, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch 
            {
                return null;
            }
            return coursesList;


        }
        public  List<CoursesSubjects> SelectCoursesSubjectsById(int CoursesID)
        {
            List<CoursesSubjects> coursesSubjects = new List<CoursesSubjects>();
            try
            {
                string StoredProcedure = "SelectCoursesSubjectsById";
              //  string query = "select CoursesSubjectsID,CoursesID,SubjectsID from CouresSubjects where CoursesID=@CoursesID";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    coursesSubjects = SqlConn.Query<CoursesSubjects>(StoredProcedure, new { @CoursesID = CoursesID }, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch
            {
                return null;
            }
            return coursesSubjects;


        }

        
        public  bool AddCourseSubject(CoursesSubjects coursesSubjects)
        {
            bool IsCourseSubjectInserted = false;
            try
            {
                //string query = "INSERT into CouresSubjects(CoursesID,SubjectsID) values(@CoursesID,@SubjectsID)";
                string StoredProcedure = "AddCourseSubject";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @CoursesID = coursesSubjects.CoursesId, @SubjectsID = coursesSubjects.SubjectsId }, commandType: CommandType.StoredProcedure);
                    IsCourseSubjectInserted = true;
                }

            }
            catch
            {
                IsCourseSubjectInserted = false;
            }
            return IsCourseSubjectInserted;
        }

        public  bool UpdateCourseSubject(CoursesSubjects coursesSubject)
        {
            bool IsStudentCourseUpdated = false;
            try
            {
               // string StoredProcedure = " UpdateCourseSubject";
                string queery = "update CouresSubjects set SubjectsID=@SubjectsID where CoursesSubjectsID=@CoursesSubjectsID and CoursesID=@CoursesID ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(queery, new { @SubjectsID = coursesSubject.SubjectsId, @CoursesID = coursesSubject.CoursesId, @CoursesSubjectsID = coursesSubject.CoursesSubjectsId });
                    IsStudentCourseUpdated = true;
                }
            }
            catch
            {
                IsStudentCourseUpdated = false;
            }
            return IsStudentCourseUpdated;
        }
        public  bool UpdateCourseSubject2(CoursesSubjects coursesSubject)
        {
            bool IsStudentCourseUpdated = false;
            try
            {
                string StoredProcedure = " UpdateCourseSubjects2";
             //   string queery = "update CouresSubjects set SubjectsID=@SubjectsID where CoursesSubjectsID=@CoursesSubjectsID and CoursesID=@CoursesID ";
                using (SqlConnection SqlConn = new SqlConnection(StoredProcedure))
                {
                    SqlConn.Execute(StoredProcedure, new { @SubjectsID = coursesSubject.SubjectsId, @CoursesID = coursesSubject.CoursesId, @CoursesSubjectsID = coursesSubject.CoursesSubjectsId }, commandType: CommandType.StoredProcedure);
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
