using AutoMapper;
using Microsoft.AspNetCore.Http;
using School.BusinessLogic.Interfaces;
using School.DataModels.Models;
using School.DataModels.Responce.Students;
using School.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace School.BusinessLogic
{
    public class StudentsBusinessLogic:IStudentsBusinessLogic
    {
        private readonly IStudentsService _studentsService;
        private readonly IMapper _mapper;


        
        public StudentsBusinessLogic(IStudentsService studentsService, IMapper mapper)
        {
            this._studentsService = studentsService;
            this._mapper = mapper;
        }
         #region Student Functions
        public Students SelectStudentByName(string StudentName)
        {
            Students students = new Students();
            students = _studentsService.SelectStudentByName(StudentName);
            return students;
        }
        public Students SelectStudentByID(int Id)
        {
            Students students = new Students();
            students = _studentsService.SelectStudentByID(Id);
            return students;
        }
        public Students SelectLastStudent()
        {
            Students student = new Students();
            student = _studentsService.SelectLastStudent();
            return student;


        }
        public List<StudentsResault> SelectAllUsers()
        {
            List<StudentsResault> usersList = new List<StudentsResault>();
            usersList = _studentsService.SelectAllUsers();
            return usersList;


        }
        public bool DeleteStudent(int StudentID)
        {
            bool StudentIsDeleted = _studentsService.DeleteStudent(StudentID);
            return StudentIsDeleted;
        }
        public List<StudentsResault> FilterByStudentName(List<StudentsResault> korisniks, string TextBox)
        {

            List<StudentsResault> korisniks1 = new List<StudentsResault>();
            foreach (var element in korisniks)
            {
                if (element.FirstName.ToLower() == TextBox.ToLower())
                {
                    korisniks1.Add(element);
                }


            }
            return korisniks1;

        }
        public List<StudentsResault> FilterByCourseName(List<StudentsResault> korisniks, string textBox)
        {
            List<StudentsResault> studentsResaults = new List<StudentsResault>();
            if (String.IsNullOrEmpty(textBox) == false)
            {


                foreach (var element in korisniks)
                {
                    if (String.IsNullOrEmpty(element.CoursesName) == false && element.CoursesName.ToLower() == textBox.ToLower())
                    {


                        studentsResaults.Add(element);

                    }

                }
            }
            else
            {

                studentsResaults.DefaultIfEmpty();
            }
            return studentsResaults;
        }

        public bool UpdateStudent(Students student)
        {
            bool StudentIsUpdated = _studentsService.UpdateStudent(student);
            return StudentIsUpdated;
        }
        public bool SaveStudent(Students student)
        {

            bool StudentIsAdded = _studentsService.SaveStudent(student);
            return StudentIsAdded;




        }
        #endregion

        #region Student Validation
        public bool ValidateFirstName(string FirstName)
        {
            bool IsFirstNameValid = false;
            if (String.IsNullOrEmpty(FirstName) || FirstName.Length < 3 || FirstName == "FirstName")
            {
                IsFirstNameValid = false;

            }
            else
            {
                IsFirstNameValid = true;
            }
            return IsFirstNameValid;

        }

        public bool ValidateLastName(string LastName)
        {
            bool IsLastNameValis = false;
            if (String.IsNullOrEmpty(LastName) || LastName.Length < 3 || LastName == "LastName")
            {
                IsLastNameValis = false;

            }
            else
            {
                IsLastNameValis = true;
            }
            return IsLastNameValis;

        }
        public bool ValidateEmail(string Email)
        {
            bool IsEmailvalid = false;
            if (String.IsNullOrEmpty(Email) || Email.Length > 5 && Email.Contains("@") == true && Email.Contains(".com") == true)
            {
                IsEmailvalid = true;
            }
            return IsEmailvalid;
        }
        public bool ValidateGender(string Gender)
        {
            bool IsGenderValid = false;
            if (String.IsNullOrEmpty(Gender) == false)
            {
                IsGenderValid = true;
            }
            return IsGenderValid;
        }
        public bool ValidateCountry(string Country)
        {
            bool IsCountryValid = false;
            if (String.IsNullOrEmpty(Country) == false)
            {
                IsCountryValid = true;
            }
            return IsCountryValid;
        }
        public bool ValidateAdress(string Adress)
        {
            bool IsAdressValid = false;
            if (String.IsNullOrEmpty(Adress) || Adress.Length < 5 || Adress == "Adress")
            {
                IsAdressValid = false;
            }
            else
            {
                IsAdressValid = true;
            }
            return IsAdressValid;
        }

        public bool ValidateEverything(bool FirstNameIsOk, bool LastNameIsOk, bool EmailIsOk, bool GenderIsOk, bool CountryIsOK, bool AdressIsOk)
        {
            bool _EverythingIsOk = false;
            if (FirstNameIsOk == true && LastNameIsOk == true && EmailIsOk == true && GenderIsOk == true && CountryIsOK == true && AdressIsOk == true)
            {
                _EverythingIsOk = true;
            }
            return _EverythingIsOk;

        }


        /*
public bool ValidateClbCourses(CheckedListBox checkedListBox)
{
   bool _isClbSubjectsValid = false;
   if (checkedListBox.CheckedItems.Count > 0)
   {
       _isClbSubjectsValid = true;
   }
   return _isClbSubjectsValid;
}

*/

        #endregion



        #region StudentBL Functions
        public StudentsBL SelectStudentBLByName(string StudentName)
        {
            Students students = new Students();
            students = _studentsService.SelectStudentByName(StudentName);
            var studentsBL = _mapper.Map<StudentsBL<Students>>(students);
            if (studentsBL.Data == null)
            {
                studentsBL.Status = StatusCodes.Status500InternalServerError.ToString();
                studentsBL.Message = "Error";
            }
            else
            {
                studentsBL.Status = StatusCodes.Status200OK.ToString();
                studentsBL.Message = "Sucsess";
            }
            return studentsBL;
        }
        public StudentsBL SelectStudentBLById(int Id)
        {
          
            Students students = new Students();
            students = _studentsService.SelectStudentByID(Id);
            var studentsBL = _mapper.Map<StudentsBL<Students>>(students);
            if (studentsBL.Data == null)
            {
                studentsBL.Status = StatusCodes.Status500InternalServerError.ToString();
                studentsBL.Message = "Error";
            }
            else
            {
                studentsBL.Status = StatusCodes.Status200OK.ToString();
                studentsBL.Message = "Sucsess";
            }
            return studentsBL;
        }

        public StudentsBL SelectLastStudentBL()
        {

            Students students = new Students();
            students = _studentsService.SelectLastStudent();
            var studentsBL = _mapper.Map<StudentsBL<Students>>(students);
            if (studentsBL.Data == null)
            {
                studentsBL.Status = StatusCodes.Status500InternalServerError.ToString();
                studentsBL.Message = "Error";
            }
            else
            {
                studentsBL.Status = StatusCodes.Status200OK.ToString();
                studentsBL.Message = "Sucsess";
            }
            return studentsBL;
        }

        public List<StudentsResaultBL<StudentsResault>> SelectAllUsersBL()
        {
            List<StudentsResault> studentsResaults = new List<StudentsResault>();
            studentsResaults = _studentsService.SelectAllUsers();
           
            var studentsResaultsBL = _mapper.Map<List<StudentsResaultBL<StudentsResault>>>(studentsResaults);

            foreach (var element in studentsResaultsBL)
            {
                if (element.Data == null)
                {
                    element.Status = StatusCodes.Status500InternalServerError.ToString();
                    element.Message = "Error";
                }
                else
                {
                    element.Status = StatusCodes.Status200OK.ToString();
                    element.Message = "Sucsess";
                }
            }
            return studentsResaultsBL;
        }

        public bool DeleteStudentBL(int StudentID)
        {
            bool IsStudentDeleted = DeleteStudent(StudentID);

            return IsStudentDeleted;
        }

        public List<StudentsResaultBL<StudentsResault>> FilterByStudentNameBL(List<StudentsResaultBL<StudentsResault>> studentsResaults, string filter)
        {
            List<StudentsResaultBL<StudentsResault>> filterdCourses = new List<StudentsResaultBL<StudentsResault>>();
            foreach (var element in studentsResaults)
            {
                if (element.Data.FirstName.ToLower().Contains(filter.ToLower()) == true)
                {
                    filterdCourses.Add(element);
                }


            }
            return filterdCourses;
        }

        public List<StudentsResaultBL<StudentsResault>> FilterByCourseNameBL(List<StudentsResaultBL<StudentsResault>> studentsResaults, string filter)
        {
            List<StudentsResaultBL<StudentsResault>> filterdCourses = new List<StudentsResaultBL<StudentsResault>>();
            foreach (var element in studentsResaults)
            {
                if (element.Data.CoursesName.ToLower().Contains(filter.ToLower()) == true)
                {
                    filterdCourses.Add(element);
                }


            }
            return filterdCourses;
        }

        public bool UpdateStudentBL(StudentsBL studentBL)
        {
            var student = _mapper.Map<Students>(studentBL);

            bool IsCourseUpdated = UpdateStudent(student);

            return IsCourseUpdated;
        }

        public bool SaveStudentBL(StudentsBL studentBL)
        {

            var student = _mapper.Map<Students>(studentBL);

            bool IsCourseSaved = SaveStudent(student);

            return IsCourseSaved;
        }
        #endregion
    }
}
