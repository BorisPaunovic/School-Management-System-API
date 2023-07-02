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
    public class TeachersServices:ITeacherServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public TeachersServices(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration.GetConnectionString("School-APIDbConnection");
        }


        public  List<TeachersJoinCoursesResault> SelectAllTeachersJoinCourses()
        {
            List<TeachersJoinCoursesResault> usersList = new List<TeachersJoinCoursesResault>();
            try
            {
                string StoredProcedure = "SelectAllTeachersJoinCourses";
               // string query = "select T.TeachersID,T.FirstName,T.LastName,T.Email,T.Gender,T.DateOfBirth,T.Adress,TC.TeachersCoursesID,C.CoursesID,C.CoursesName,C.CoursesDescription from Teachers as T left join TeachersCourses as TC on t.TeachersID= TC.TeachersID left join Courses as C on TC.CoursesID= C.CoursesID  ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    usersList = SqlConn.Query<TeachersJoinCoursesResault>(StoredProcedure, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch 
            {

            }
            return usersList;


        }
        public  bool SaveTeacher(Teachers teacher)
        {
            bool StudentIsAdded = false;


            try
            {
                string StoredProcedure = "SaveTeacher";
              //  string qery = "insert into Teachers(FirstName,LastName,Email,Gender,DateOfBirth,Adress)values(@FirstName,@LastName,@Email,@Gender,@DateOfBirth,@Adress)";
                using (var SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @FirstName = teacher.FirstName, @LastName = teacher.LastName, @Email = teacher.Email, @Gender =teacher.Gender, @DateOfBirth = teacher.DateOfBirth, @Adress = teacher.Adress }, commandType: CommandType.StoredProcedure);
                    StudentIsAdded = true;
                }

            }
            catch 
            {
                StudentIsAdded = false;
            }
            return StudentIsAdded;








        }
        public  Teachers SelectTeacherByName(string TeacherName)
        {
            Teachers courses = new Teachers();
            try
            {
                string StoredProcedure = "SelectTeacherByName";
             //   string query = "  select TeachersID,FirstName,LastName,Email,Gender,DateOfBirth,Adress from Teachers where FirstName = @FirstName";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    courses = SqlConn.QueryFirst<Teachers>(StoredProcedure, new { @FirstName = TeacherName }, commandType: CommandType.StoredProcedure);
                }


            }
            catch
            {

            }
            return courses;
        }
        public  bool DeleteTeacher(int TeacherId)
        {
            bool TeacherIsDeleted = false;
            int affectedRows = 0;

            try
            {
                string StoredProcedure = "DeleteTeacher";
             //   string query = "delete TeachersCourses  where TeachersID = @TeachersID delete Teachers where TeachersID = @TeachersID";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    affectedRows = SqlConn.Execute(StoredProcedure, new { @TeachersID = TeacherId }, commandType: CommandType.StoredProcedure);
                    if (affectedRows != 0)
                    {
                        TeacherIsDeleted = true;
                    }
                }

            }
            catch
            {
                if (affectedRows == 0)
                {
                    TeacherIsDeleted = false;
                }
            }
            return TeacherIsDeleted;







        }
        public  bool UpdateTeacher(Teachers teacher)
        {
            bool IsTeacherUpdated = false;
            try
            {
                string StoredProcedure = "UpdateTeacher";
               // string queery = "update Teachers set FirstName=@FirstName,LastName=@LastName,Adress=@Adress,Email=@Email,DateOfBirth=@DateOfBirth,Gender=@Gender where TeachersID= @TeachersId ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @TeachersId = teacher.TeachersId, @FirstName = teacher.FirstName, @LastName = teacher.LastName, @Adress = teacher.Adress, @Email = teacher.Email, @DateOfBirth = teacher.DateOfBirth, @Gender = teacher.Gender }, commandType: CommandType.StoredProcedure);
                    IsTeacherUpdated = true;
                }
            }
            catch
            {
                IsTeacherUpdated = false;
            }
            return IsTeacherUpdated;
        }

        public Teachers SelectTeacherByID(int Id)
        {
            Teachers teachers = new Teachers();
            try
            {
                string StoredProcedure = "SelectTeacherById";
                // string query = " select StudentsID,FirstName,LastName,Email,Gender,DateOfBirth,Adress,CountriesID from Students where FirstName=@FirstName";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    teachers = SqlConn.QueryFirst<Teachers>(StoredProcedure, new { @TeachersId = Id }, commandType: CommandType.StoredProcedure);
                }


            }
            catch
            {

            }
            return teachers;
        }
        public List<Teachers> SelectAllTeachers()
        {
            List<Teachers> teachersList = new List<Teachers>();
            try
            {
                string StoredProcedure = "SelectAllTeachers";
                // string query = "select T.TeachersID,T.FirstName,T.LastName,T.Email,T.Gender,T.DateOfBirth,T.Adress,TC.TeachersCoursesID,C.CoursesID,C.CoursesName,C.CoursesDescription from Teachers as T left join TeachersCourses as TC on t.TeachersID= TC.TeachersID left join Courses as C on TC.CoursesID= C.CoursesID  ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    teachersList = SqlConn.Query<Teachers>(StoredProcedure, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch
            {

            }
            return teachersList;
        }



    }
}
