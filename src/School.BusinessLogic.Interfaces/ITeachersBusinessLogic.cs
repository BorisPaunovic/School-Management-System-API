using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces
{
    public interface ITeachersBusinessLogic
    {
        #region Teachers Functions
        public Teachers SelectTeacherByName(string TeacherName);


        public List<TeachersJoinCoursesResault> SelectAllTeachersJoinCourses();


        public List<TeachersJoinCoursesResault> FilterByTeacherName(List<TeachersJoinCoursesResault> korisniks, string TextBox);


        public List<TeachersJoinCoursesResault> FilterByCourseName(List<TeachersJoinCoursesResault> korisniks, string textBox);


        public bool SaveTeacher(Teachers teacher);



        public bool ValidateFirstName(string FirstName);



        public bool ValidateLastName(string LastName);


        public bool ValidateEmail(string Email);


        public bool ValidateGender(string Gender);



        public bool ValidateAdress(string Adress);


     //   public bool ValidateClbCourses(CheckedListBox checkedListBox);


        public bool ValidateEverything(bool FirstNameIsOk, bool LastNameIsOk, bool EmailIsOk, bool GenderIsOk, bool AdressIsOk, bool clbCoursesIsOk);


        public bool DeleteTeacher(int TeacherId);

        public Teachers SelectTeacherByID(int Id);
        public List<Teachers> SelectAllTeachers();

        public bool UpdateTeacher(Teachers teacher);
        #endregion





        public TeachersBL<Teachers> SelectTeacherBLByID(int Id);
        #region TeachersBL Functions

        public List<TeachersBL<Teachers>> SelectAllTeachersBL();
        public TeachersBL<Teachers> SelectTeacherBLByName(string TeacherName);


        public List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> SelectAllTeachersJoinCoursesBL();


        public List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> FilterByTeacherBLName(List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> korisniks, string TextBox); 


        public List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> FilterByCourseNameBL(List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> korisniks, string textBox);


        public bool SaveTeacherBL(TeachersBL<Teachers> teacher);

        public bool DeleteTeacheBL(int TeacherId);

        public bool UpdateTeacherBL(TeachersBL<Teachers> teacher);
        #endregion


    }
}
