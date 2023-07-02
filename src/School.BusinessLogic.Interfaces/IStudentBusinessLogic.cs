using School.BusinessModels.Responce.Students;
using System.Collections.Generic;

namespace School.BusinessLogic.Interfaces
{
    public interface IStudentBusinessLogic
    {
        public List<GetStudentResponce> GetAllStudents();
        string Test();
    }
}
