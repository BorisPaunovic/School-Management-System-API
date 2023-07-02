using AutoMapper;
using Microsoft.AspNetCore.Http;
using School.BusinessLogic.Interfaces;
using School.DataModels.Models;
using School.Services;
using School.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic
{
    public class TeachersBusinessLogic: ITeachersBusinessLogic
    {

        private readonly ITeacherServices _teachersServices;
        private readonly IMapper _mapper;



        public TeachersBusinessLogic(ITeacherServices teachersServices, IMapper mapper)
        {
            this._teachersServices = teachersServices;
            this._mapper = mapper;
        }

        #region Teachers Region

        public Teachers SelectTeacherByID(int Id)
        {
            var teacher = _teachersServices.SelectTeacherByID(Id);
            return teacher;
        }

        public Teachers SelectTeacherByName(string TeacherName)
        {
            Teachers teachers = new Teachers();
            teachers = _teachersServices.SelectTeacherByName(TeacherName);
            return teachers;
        }
        public List<TeachersJoinCoursesResault> SelectAllTeachersJoinCourses()
        {
            List<TeachersJoinCoursesResault> teachersJoinCoursesResaults = new List<TeachersJoinCoursesResault>();
            teachersJoinCoursesResaults = _teachersServices.SelectAllTeachersJoinCourses();
            return teachersJoinCoursesResaults;

        }
        public List<Teachers> SelectAllTeachers()
        {
            List< Teachers> teachers = new List<Teachers>();
            teachers = _teachersServices.SelectAllTeachers();
            return teachers;
        }
        public List<TeachersJoinCoursesResault> FilterByTeacherName(List<TeachersJoinCoursesResault> korisniks, string TextBox)
        {

            List<TeachersJoinCoursesResault> Teacher = new List<TeachersJoinCoursesResault>();
            if (String.IsNullOrEmpty(TextBox) == false)
            {
                foreach (var element in korisniks)
                {
                    if (String.IsNullOrEmpty(element.FirstName) == false && element.FirstName.ToLower().Contains(TextBox.ToLower()))
                    {


                        Teacher.Add(element);

                    }


                }
            }
            else
            {
                Teacher.DefaultIfEmpty();
            }
            return Teacher;

        }
        public List<TeachersJoinCoursesResault> FilterByCourseName(List<TeachersJoinCoursesResault> korisniks, string textBox)
        {
            List<TeachersJoinCoursesResault> CourseName = new List<TeachersJoinCoursesResault>();
            if (String.IsNullOrEmpty(textBox) == false)
            {
                foreach (var element in korisniks)
                {

                    if (String.IsNullOrEmpty(element.CoursesName) == false && element.CoursesName.ToLower().Contains(textBox.ToLower()))
                    {


                        CourseName.Add(element);

                    }


                }
            }
            else
            {
                CourseName.DefaultIfEmpty();
            }
            return CourseName;
        }
        public bool SaveTeacher(Teachers teacher)
        {
            bool TeacherIsAdded = false;
            TeacherIsAdded = _teachersServices.SaveTeacher(teacher);
            return TeacherIsAdded;
        }

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
        /*
        public bool ValidateClbCourses(CheckedListBox checkedListBox)
        {
            bool _isClbSubjectsValid = false;
            if (checkedListBox.CheckedItems.Count > 0)
            {
                _isClbSubjectsValid = true;
            }
            return _isClbSubjectsValid;
        }*/
        public bool ValidateEverything(bool FirstNameIsOk, bool LastNameIsOk, bool EmailIsOk, bool GenderIsOk, bool AdressIsOk, bool clbCoursesIsOk)
        {
            bool _EverythingIsOk = false;
            if (FirstNameIsOk == true && LastNameIsOk == true && EmailIsOk == true && GenderIsOk == true && clbCoursesIsOk == true && AdressIsOk == true)
            {
                _EverythingIsOk = true;
            }
            return _EverythingIsOk;

        }
        public bool DeleteTeacher(int TeacherId)
        {
            bool TeacherIsDeleted = false;
            TeacherIsDeleted = _teachersServices.DeleteTeacher(TeacherId);
            return TeacherIsDeleted;
        }

        public bool UpdateTeacher(Teachers teacher)
        {
            bool IsTeacherUpdated = false;
            IsTeacherUpdated = _teachersServices.UpdateTeacher(teacher);
            return IsTeacherUpdated;
        }


        #endregion




        #region TeachersBL
        public TeachersBL<Teachers> SelectTeacherBLByName(string TeacherName)
        {

            Teachers teacher = new Teachers();

            teacher = _teachersServices.SelectTeacherByName(TeacherName);
            var teacherBL = _mapper.Map<TeachersBL<Teachers>>(teacher);
            if (teacherBL.Data == null)
            {
                teacherBL.Status = StatusCodes.Status500InternalServerError.ToString();
                teacherBL.Message = "Error";
            }
            else
            {
                teacherBL.Status = StatusCodes.Status200OK.ToString();
                teacherBL.Message = "Sucsess";
            }
            return teacherBL;
        }

        public List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> SelectAllTeachersJoinCoursesBL()
        {
            List<TeachersJoinCoursesResault> TJC = new List<TeachersJoinCoursesResault>();
            TJC = SelectAllTeachersJoinCourses();

            var TJCBL = _mapper.Map<List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>>>(TJC);

            foreach (var element in TJCBL)
            {
                if (TJCBL.FirstOrDefault().Data == null)
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
            return TJCBL;
        }
        public List<TeachersBL<Teachers>> SellectAllTeachers()
        {
            List<Teachers> teachers = new List<Teachers>();
            teachers = SelectAllTeachers();

            var teachersBL = _mapper.Map<List<TeachersBL<Teachers>>>(teachers);

            foreach (var element in teachersBL)
            {
                if (teachersBL.FirstOrDefault().Data == null)
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
            return teachersBL;
        }

        public List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> FilterByTeacherBLName(List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> teachers, string filter)
        {
            List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> filterdTeachers = new List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> ();
            foreach (var element in teachers)
            {
                if (element.Data.FirstName.ToLower().Contains(filter.ToLower()) == true)
                {
                    filterdTeachers.Add(element);
                }


            }
            return filterdTeachers;
        }

        public List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> FilterByCourseNameBL(List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> teachers, string filter)
        {
            List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> filterdTeachers = new List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>>();
            foreach (var element in teachers)
            {
                if (element.Data.CoursesName.ToLower().Contains(filter.ToLower()) == true)
                {
                    filterdTeachers.Add(element);
                }


            }
            return filterdTeachers;
        }

        public bool SaveTeacherBL(TeachersBL<Teachers> teacherBL)
        {
            var teacher = _mapper.Map<Teachers>(teacherBL);

            bool IsTeacherSaved = SaveTeacher(teacher);

            return IsTeacherSaved;
        }

        public bool DeleteTeacheBL(int TeacherId)
        {

            bool IsTeacherDeleted = DeleteTeacher(TeacherId);

            return IsTeacherDeleted;
        }

        public bool UpdateTeacherBL(TeachersBL<Teachers> teacherBL)
        {
            var teacher = _mapper.Map<Teachers>(teacherBL);

            bool IsTeacherUpdated = UpdateTeacher(teacher);

            return IsTeacherUpdated;
        }

        

        public TeachersBL<Teachers> SelectTeacherBLByID(int Id)
        {
            var teacher = SelectTeacherByID(Id);
            var teacherBL = _mapper.Map<TeachersBL<Teachers>>(teacher);
            return teacherBL;
        }

        public List<TeachersBL<Teachers>> SelectAllTeachersBL()
        {
            var teacher = SelectAllTeachers();
            var teacherBL = _mapper.Map<List<TeachersBL<Teachers>>>(teacher);
            return teacherBL;
        }
        #endregion

    }
}
