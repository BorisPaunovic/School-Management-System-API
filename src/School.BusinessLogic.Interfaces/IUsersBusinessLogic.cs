using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces
{
    public interface IUsersBusinessLogic
    {

        #region Users Functions
        public bool DeleteUser(int UserId);

        public List<Users> SelectAllUsers();

        public Users GetUserByUsername(string users);

        public bool InsertUser(Users user);



        public List<Users> FilterByUserName(List<Users> users1, string TextBox);



        public bool UpdateUser(Users users);



        public bool ValidatePassword(string SignInPassword, string DbPassword);


        public bool ValidateUser(bool usernameIsValid, bool passwordIsValid);


        public bool ValidateUserSignUp(bool usernameIsValid, bool emailIsValid, bool passwordIsvalid);


        public bool ValidateUsernameLogIn(string DbUsername, string usernametb);


        public bool ValidateUsernameSingUp(string DbUsername, string LogInUsername);


        public bool ValidatePasswordSingUp(string password, string repeatPassword);


        public bool ValidateEmailSingUp(string UserEmail, string dbEmail);
        #endregion



        #region UsersBL Functions
        public bool DeleteUserBL(int UserId);

        public List<UsersBL<Users>> SelectAllUsersBL();

        public UsersBL<Users> GetUserByUsernameBL(string users);

        public bool InsertUserBL(UsersBL<Users> user);



        public List<UsersBL<Users>> FilterByUserNameBL(List<UsersBL<Users>> users1, string TextBox);



        public bool UpdateUserBL(UsersBL<Users> users);

        #endregion

    }
}
