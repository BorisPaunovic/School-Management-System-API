using System;

namespace School.BusinessModels.Responce.Students
{
    public class GetStudentResponce
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int EnrolledStudentId { get; set; }
        public int ClassId { get; set; }
        public int DepartmentId { get; set; }
        public int Year { get; set; }
        public string DepartmentName { get; set; }
    }
}
