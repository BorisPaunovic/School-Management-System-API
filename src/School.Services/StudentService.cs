using Dapper;
using Microsoft.Extensions.Configuration;
using School.DataModels.Responce.Students;
using School.Services.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace School.Services
{
    public class StudentService : IStudentService
    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;
        private List<Student> _students;
        // private string _getAllStudents = "SELECT ID, FIRSTNAME, LASTNAME, BIRTHDATE FROM STUDENTS";
        public StudentService(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("School-APIDbConnection");
        }
        public string Test()
        {

            return _connectionString;
        }
        public List<Student> GetAllStudents()
        {
            _students = new List<Student>();
            try
            {
                using (var sqlConnnection = new SqlConnection(_connectionString))
                {
                    //  _students = sqlConnnection.Query<GetStudentResponce>(_getAllStudents).ToList();
                    _students = sqlConnnection.Query<Student>("GetAllStudents", commandType: CommandType.StoredProcedure).ToList();
                    return _students;
                }
            }
            catch
            {
                return _students;
            }
        }

    }
}
