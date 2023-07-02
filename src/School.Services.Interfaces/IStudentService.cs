using School.DataModels.Responce.Students;
using System.Collections.Generic;

namespace School.Services.Interfaces
{
    public interface IStudentService
    {
        string Test();
        public List<Student> GetAllStudents();
    }
}
