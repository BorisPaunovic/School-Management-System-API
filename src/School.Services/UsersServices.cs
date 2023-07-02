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
    public class UsersServices:IUsersServices
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public UsersServices(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration.GetConnectionString("School-APIDbConnection");
        }


      
        public bool DeleteUser(int UserId)
        {
            bool UserIsDeleted = false;
            int affectedRows = 0;

            try
            {
                string StoredProcedure = "DeleteUser";
              //  string query = "delete  from Users where UsersID= @UserID";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    affectedRows = SqlConn.Execute(StoredProcedure, new { @UserID = UserId }, commandType: CommandType.StoredProcedure);
                    // affectedRows = SqlConn.Execute(query, new { @UserID = UserId });
                    if (affectedRows != 0)
                    {
                        UserIsDeleted = true;
                    }
                }

            }
            catch
            {
                if (affectedRows == 0)
                {
                    UserIsDeleted = false;
                }
            }
            return UserIsDeleted;







        }
        public  List<Users> SelectAllUsers()
        {
            List<Users> usersList = new List<Users>();
            try
            {
                string StoredProcedure = "SelectAllUsers";
              //  string query = "SELECT UsersID,UserName,UserEmail,UserPassword,Administrator FROM Users ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    usersList = SqlConn.Query<Users>(StoredProcedure, commandType: CommandType.StoredProcedure).ToList();
                    // usersList = SqlConn.Query<Users>(query).ToList();
                }
            }
            catch
            {
                usersList = new List<Users>()
                {
                    new Users{UsersID=0,UserName=null,UserPassword=null,UserEmail=null,Administrator=false }
                };
            }
            return usersList;


        }
        public  Users GetUserByUsername(string Username)
        {
            Users users = new Users();


            try
            {
                string StoredProcedure = "GetUserByUsername";
               // string query = "Select Username,UserPassword,UserEmail,Administrator FROM Users where Username=@Username";
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    users = conn.QueryFirst<Users>(StoredProcedure, new { @Username = Username }, commandType: CommandType.StoredProcedure);

                }
            }
            catch
            {
                users = new Users()
                {
                    UsersID = 0,
                    UserName = null,
                    UserEmail = null,
                    UserPassword = null,
                    Administrator = false


                };

            };



            return users;


        }
        public  bool InsertUser(Users user)
        {
            bool success = false;
            try
            {
                string StoredProcedure = "InsertUser";
               // string query = "INSERT INTO Users(UserName,UserPassword,UserEmail,Administrator) VALUES(@UserName,@UserPassword,@UserEmail,@Administrator)";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @UserName = user.UserName, @UserPassword = user.UserPassword, @UserEmail = user.UserEmail, @Administrator = user.Administrator }, commandType: CommandType.StoredProcedure);

                    success = true;
                }
            }
            catch
            {
                success = false;
            }
            return success;

        }
        public  bool UpdateUser(Users users)
        {

            bool IsStudentCourseUpdated = false;
            try
            {
                string StoredProcedure = "UpdateUser";
              //  string queery = "update Users set Administrator=@Administrator where Usersid=@UserId ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @UserId = users.UsersID, @Administrator = users.Administrator }, commandType: CommandType.StoredProcedure);
                    //  SqlConn.Execute(queery, new { @UserId = users.UsersID, @Administrator = users.Administrator });
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
