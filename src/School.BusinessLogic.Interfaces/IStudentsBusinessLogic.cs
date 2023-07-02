using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces
{
    public interface IStudentsBusinessLogic
    {

        #region Students Functions

        public Students SelectStudentByID(int Id);
        public Students SelectStudentByName(string StudentName);

        public Students SelectLastStudent();

        public List<StudentsResault> SelectAllUsers();

        public bool DeleteStudent(int StudentID);

        public List<StudentsResault> FilterByStudentName(List<StudentsResault> korisniks, string TextBox);

        public List<StudentsResault> FilterByCourseName(List<StudentsResault> korisniks, string textBox);

        public bool UpdateStudent(Students student);

        public bool SaveStudent(Students student);
        #endregion
        #region Students Functions

        public StudentsBL SelectStudentBLById(int Id);
        public StudentsBL SelectStudentBLByName(string StudentName);

        public StudentsBL SelectLastStudentBL();

        public List<StudentsResaultBL<StudentsResault>> SelectAllUsersBL();

        public bool DeleteStudentBL(int StudentID);

        public List<StudentsResaultBL<StudentsResault>> FilterByStudentNameBL(List<StudentsResaultBL<StudentsResault>> korisniks, string TextBox);

        public List<StudentsResaultBL<StudentsResault>> FilterByCourseNameBL(List<StudentsResaultBL<StudentsResault>> korisniks, string textBox);

        public bool UpdateStudentBL(StudentsBL student);

        public bool SaveStudentBL(StudentsBL student);
        #endregion


    }
}
