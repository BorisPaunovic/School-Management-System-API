using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic.Interfaces;
using School.DataModels.Models;
using System.Collections.Generic;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersBusinessLogic _usersBusinessLogic;

        public UsersController(IUsersBusinessLogic usersBusinessLogic)
        {
            this._usersBusinessLogic = usersBusinessLogic;
        }
        [HttpGet]
        
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _usersBusinessLogic.SelectAllUsers();



                return Ok(users);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        /*
        [HttpGet("Get/{Id}")]



        public IActionResult GetUserById(int Id)
        {
            try
            {
                var courseBL = _usersBusinessLogic.SelectUserById(Id);
                return Ok(courseBL);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        */

        [HttpGet("Name/{name}")]

        public IActionResult GetUserByUsername(string name)
        {
            try
            {
                var user = _usersBusinessLogic.GetUserByUsernameBL(name);
                return Ok(user);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPost]

        public IActionResult AddUser(UsersBL<Users> usersBL)
        {
            try
            {
                var IsuersBLAdded = _usersBusinessLogic.InsertUserBL(usersBL);
                return Ok(IsuersBLAdded);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpDelete]

        public IActionResult DeleteUser(int Id)
        {
            try
            {
                var country = _usersBusinessLogic.DeleteUserBL(Id);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPut]
        public IActionResult UpdateUser(UsersBL<Users> usersBL)
        {

            try
            {
                var IsUserUpdated = _usersBusinessLogic.UpdateUserBL(usersBL);
                return Ok(IsUserUpdated);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }



        [HttpPost("{filter}")]
       public IActionResult FilterUsersByName (List<Users> users ,string filter)
        {
            var filterdUsers = _usersBusinessLogic.FilterByUserName(users, filter);
            return Ok(filterdUsers);

        }

    }
}
