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
using AutoMapper;
using School.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using School.Services;

namespace School.BusinessLogic
{
    public class UsersBusinessLogic : IUsersBusinessLogic
    {
        private readonly IUsersServices _usersServices;
        private readonly IMapper _mapper;



        public UsersBusinessLogic(IUsersServices teachersServices, IMapper mapper)
        {
            this._usersServices = teachersServices;
            this._mapper = mapper;
        }
        #region Users Functions

        public bool DeleteUser(int UserId)
        {
            bool UserIsDeleted = _usersServices.DeleteUser(UserId);
            return UserIsDeleted;
        }
        public List<Users> SelectAllUsers()
        {
            List<Users> usersList = new List<Users>();
            usersList = _usersServices.SelectAllUsers();
            return usersList;


        }

        public Users GetUserByUsername(string users)
        {
            Users user = new Users();
            user = _usersServices.GetUserByUsername(users);
            return user;

        }
        public bool InsertUser(Users user)
        {

            bool success = _usersServices.InsertUser(user);
            return success;


        }

        public List<Users> FilterByUserName(List<Users> users1, string TextBox)
        {

            List<Users> users = new List<Users>();
            foreach (var element in users1)
            {
                if (element.UserName.ToLower().Contains(TextBox.ToLower()) == true)
                {
                    users.Add(element);
                }


            }
            return users;

        }

        public bool UpdateUser(Users users)
        {
            bool UserIsUpdated = _usersServices.UpdateUser(users);
            return UserIsUpdated;
        }

        public bool ValidatePassword(string SignInPassword, string DbPassword)
        {
            bool PasswordIsCorrect = true;
            if (SignInPassword == DbPassword)
            {
                PasswordIsCorrect = true;

            }
            else if (SignInPassword != DbPassword || String.IsNullOrEmpty(DbPassword) == true)
            {
                PasswordIsCorrect = false;

            }
            return PasswordIsCorrect;

        }
        public bool ValidateUser(bool usernameIsValid, bool passwordIsValid)
        {
            bool IsUserValid = false;
            if (usernameIsValid == true && passwordIsValid == true)
            {
                IsUserValid = true;

            }

            return IsUserValid;

        }
        public bool ValidateUserSignUp(bool usernameIsValid, bool emailIsValid, bool passwordIsvalid)
        {
            bool ContainsUsername = false;

            if (usernameIsValid == true && emailIsValid == true && passwordIsvalid == true)
            {
                ContainsUsername = true;

            }
            return ContainsUsername;
        }
        public bool ValidateUsernameLogIn(string DbUsername, string usernametb)
        {
            bool UsernameIsCorrect = false;
            if (String.IsNullOrEmpty(usernametb) == false && usernametb == DbUsername)

            {
                UsernameIsCorrect = true;


            }

            return UsernameIsCorrect;
        }
        public bool ValidateUsernameSingUp(string DbUsername, string LogInUsername)
        {
            bool UsernameIsCorrect = false;


            if (String.IsNullOrEmpty(LogInUsername) == false && LogInUsername != DbUsername && LogInUsername.Length > 5)
            {
                UsernameIsCorrect = true;


            }

            return UsernameIsCorrect;


        }
        public bool ValidatePasswordSingUp(string password, string repeatPassword)
        {
            bool PasswordIsValid = false;
            if (String.IsNullOrEmpty(password) == false && String.IsNullOrEmpty(repeatPassword) == false && password == repeatPassword && password.Length > 5)
            {
                PasswordIsValid = true;

            }

            return PasswordIsValid;
        }
        public bool ValidateEmailSingUp(string UserEmail, string dbEmail)
        {
            bool Emaililisvalid = false;

            if (String.IsNullOrEmpty(dbEmail) && UserEmail.Contains("@"))
            {
                Emaililisvalid = true;

            }
            else if (String.IsNullOrEmpty(dbEmail) == false)
            {
                if (UserEmail == dbEmail)
                {
                    Emaililisvalid = false;
                }
            }
            return Emaililisvalid;
        }


        #endregion



        #region UserbBL Region


        public bool DeleteUserBL(int UserId)
        {
            bool IsUserDeleted = DeleteUser(UserId);

            return IsUserDeleted;
        }

        public List<UsersBL<Users>> SelectAllUsersBL()
        {
            List<Users> users = new List<Users>();
            users = SelectAllUsers();

            var usersBL = _mapper.Map<List<UsersBL<Users>>>(users);

            foreach (var element in usersBL)
            {
                if (usersBL.FirstOrDefault().Data == null)
                {
                    element.Status = StatusCodes.Status500InternalServerError.ToString();
                    element.Message = "Error";
                }
                else
                {
                    element.Status = StatusCodes.Status200OK.ToString();
                    element.Message = "Sucsess";
                }
            }
            return usersBL;
        }

        public UsersBL<Users> GetUserByUsernameBL(string users)
        {

            Users user = new Users();

            user = _usersServices.GetUserByUsername(users);
            var userBL = _mapper.Map<UsersBL<Users>>(user);
            if (userBL.Data == null)
            {
                userBL.Status = StatusCodes.Status500InternalServerError.ToString();
                userBL.Message = "Error";
            }
            else
            {
                userBL.Status = StatusCodes.Status200OK.ToString();
                userBL.Message = "Sucsess";
            }
            return userBL;
        }

        public bool InsertUserBL(UsersBL<Users> userBL)
        {
            var user = _mapper.Map<Users>(userBL);

            bool IsUserSaved = InsertUser(user);

            return IsUserSaved;
        }

        public List<UsersBL<Users>> FilterByUserNameBL(List<UsersBL<Users>> usersBL, string filter)
        {
            List<UsersBL<Users>> filterdUsers = new List<UsersBL<Users>>();
            foreach (var element in usersBL)
            {
                if (element.Data.UserName.ToLower().Contains(filter.ToLower()) == true)
                {
                    filterdUsers.Add(element);
                }


            }
            return filterdUsers;
        }

        public bool UpdateUserBL(UsersBL<Users> users)
        {
            var user = _mapper.Map<Users>(users);

            bool IsTeacherUpdated = UpdateUser(user);

            return IsTeacherUpdated;
        }

        #endregion
    }


}
