using AutoMapper;
using School.BusinessLogic.Interfaces;
using School.BusinessModels.Responce.Students;
using School.DataModels.Responce.Students;
using School.Services.Interfaces;
using System.Collections.Generic;

namespace School.BusinessLogic
{
    public class StudentBusinessLogic : IStudentBusinessLogic
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        List<Student> _students = new List<Student>();
        private List<GetStudentResponce> _getStudentResponces;
        public StudentBusinessLogic(IStudentService studentService, IMapper _mapper)
        {
            this.studentService = studentService;
            mapper = _mapper;
        }
        public string Test()
        {
            string test = studentService.Test();
            return test + "" + "UwU";
        }
        public List<GetStudentResponce> GetAllStudents()
        {
            _students = new List<Student>();
            _students = studentService.GetAllStudents();
            _getStudentResponces = new List<GetStudentResponce>();
            _getStudentResponces = mapper.Map<List<GetStudentResponce>>(_students);

            return _getStudentResponces;

        }


    }
}
