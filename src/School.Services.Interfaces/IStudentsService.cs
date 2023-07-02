using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface IStudentsService
    {
        public Students SelectStudentByName(string StudentName);

        public List<StudentsResault> SelectAllUsers();


        public Students SelectLastStudent();

        public bool DeleteStudent(int StudentID);

        public bool UpdateStudent(Students student);

        public bool SaveStudent(Students student);
        public Students SelectStudentByID(int Id);
       










    }
}
