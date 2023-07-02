using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface IUsersServices
    {

     
        public bool DeleteUser(int UserId);


        public List<Users> SelectAllUsers();


        public Users GetUserByUsername(string Username);


        public bool InsertUser(Users user);


        public bool UpdateUser(Users users);
       
       
    }
}
