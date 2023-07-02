using AutoMapper;
using Microsoft.AspNetCore.Http;
using School.BusinessLogic.Interfaces;
using School.DataModels.Models;
using School.DataModels.Responce.Students;
using School.Services;
using School.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic
{
    public class SubjectsBusinessLogic:ISubjectsBusinessLogic
    {

        private readonly ISubjectsServices _subjecstservice;
        private readonly IMapper _mapper;



        public SubjectsBusinessLogic(ISubjectsServices subjecstservice, IMapper mapper)
        {
            this._subjecstservice = subjecstservice;
            this._mapper = mapper;
        }

        #region Subjects Functions
        public Subjects SelectSubjectById(int Id)
        {
            Subjects subjects = new Subjects();
            subjects =_subjecstservice.SelectSubjectById(Id);
            return subjects;
        }
        public bool DeleteSubject(int SubjectId)
        {
            bool SubjectIsDeleted = false;
            SubjectIsDeleted = _subjecstservice.DeleteSubject(SubjectId);
            return SubjectIsDeleted;
        }
        public Subjects SelectSubjectByName(string subject)
        {
            Subjects subjects = new Subjects();
            subjects = _subjecstservice.SelectSubjectByName(subject);
            return subjects;
        }
        public List<Subjects> SelectAllSubjects()
        {
            List<Subjects> subjects = new List<Subjects>();
            subjects = _subjecstservice.SelectAllSubjects();
            return subjects;
        }
        public bool SaveSubject(Subjects subject)
        {
            bool IsSubjectsSaved = false;
            IsSubjectsSaved = _subjecstservice.SaveSubject(subject);
            return IsSubjectsSaved;
        }
        public bool ValidateSubjectName(string subject)
        {
            bool IsUnique = String.IsNullOrEmpty(SelectSubjectByName(subject).SubjectName);
            bool isNameValid = false;
            if (String.IsNullOrEmpty(subject) == false && IsUnique == true)
            {
                isNameValid = true;
            }
            else
            {
                isNameValid = false;
            }
            return isNameValid;
        }
        public bool ValidateSubjectName2(string subject)
        {

            bool isNameValid = false;
            if (String.IsNullOrEmpty(subject) == false)
            {
                isNameValid = true;
            }
            else
            {
                isNameValid = false;
            }
            return isNameValid;
        }
        public bool ValidateSubjectDescription(string subject)
        {
            bool isDescriptionValid = false;
            if (String.IsNullOrEmpty(subject) == false)
            {
                isDescriptionValid = true;
            }
            else
            {
                isDescriptionValid = false;
            }
            return isDescriptionValid;
        }
        public List<Subjects> FilterBySubjectName(List<Subjects> oldsubjectList, string TextBox)
        {

            List<Subjects> newSubjectList = new List<Subjects>();
            foreach (var element in oldsubjectList)
            {
                if (element.SubjectName.ToLower().Contains(TextBox.ToLower()) == true)
                {
                    newSubjectList.Add(element);
                }



            }
            return newSubjectList;

        }
        public bool UpdateSubject(Subjects subject)
        {
            bool IsCourseUpdated = false;
            IsCourseUpdated = _subjecstservice.UpdateSubject(subject);
            return IsCourseUpdated;
        }


        #endregion


        #region SubjectsBL Functions

        public SubjectsBL<Subjects> SelectSubjectBLById(int id) 
        {
            var subjects = SelectSubjectById(id);
            var subjectBL = _mapper.Map<SubjectsBL<Subjects>>(subjects);
            return subjectBL;

        }

        public bool DeleteSubjectBL(int SubjectId)
        {
            bool IsSubjectDeleted = DeleteSubject(SubjectId);

            return IsSubjectDeleted;
        }

        public SubjectsBL<Subjects> SelectSubjectBLByName(string subjectBLName)
        {
            Subjects subject = new Subjects();
        
            subject = _subjecstservice.SelectSubjectByName(subjectBLName);
            var subjectBL = _mapper.Map<SubjectsBL<Subjects>>(subject);
            if (subjectBL.Data == null)
            {
                subjectBL.Status = StatusCodes.Status500InternalServerError.ToString();
                subjectBL.Message = "Error";
            }
            else
            {
                subjectBL.Status = StatusCodes.Status200OK.ToString();
                subjectBL.Message = "Sucsess";
            }
            return subjectBL;
        }

        public List<SubjectsBL<Subjects>> SelectAllSubjectsBL()
        {
            List<Subjects> subject = new List<Subjects>();
            subject = SelectAllSubjects();

            var subjectsBL = _mapper.Map<List<SubjectsBL<Subjects>>>(subject);

            foreach (var element in subjectsBL)
            {
                if (subjectsBL.FirstOrDefault().Data == null)
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
            return subjectsBL;
        }

        public bool SaveSubjectBL(SubjectsBL<Subjects> subjectBL)
        {
            var student = _mapper.Map<Subjects>(subjectBL);

            bool IsCourseSaved = SaveSubject(student);

            return IsCourseSaved;
        }

       

        public List<SubjectsBL<Subjects>> FilterBySubjectBLName(List<SubjectsBL<Subjects>> subjectBLList, string filter)
        {
            List<SubjectsBL<Subjects>> filterdCourses = new List<SubjectsBL<Subjects>>();
            foreach (var element in subjectBLList)
            {
                if (element.Data.SubjectName.ToLower().Contains(filter.ToLower()) == true)
                {
                    filterdCourses.Add(element);
                }


            }
            return filterdCourses;
        }

        public bool UpdateSubjectBL(SubjectsBL<Subjects> subjectBLList)
        {
            var subject = _mapper.Map<Subjects>(subjectBLList);

            bool IsSubjectUpdated = UpdateSubject(subject);

            return IsSubjectUpdated;
        }
        #endregion
    }
}
