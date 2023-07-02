using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces
{
    public interface ISubjectsBusinessLogic
    {

        #region Subjects Functions

        public bool DeleteSubject(int SubjectId);


        public Subjects SelectSubjectByName(string subject);
        public Subjects SelectSubjectById(int Id);


        public List<Subjects> SelectAllSubjects();


        public bool SaveSubject(Subjects subject);


        public bool ValidateSubjectName(string subject);


        public bool ValidateSubjectName2(string subject);


        public bool ValidateSubjectDescription(string subject);


        public List<Subjects> FilterBySubjectName(List<Subjects> oldsubjectList, string TextBox);


        public bool UpdateSubject(Subjects subject);

        #endregion



        #region SubjectsBL Functions
        public SubjectsBL<Subjects> SelectSubjectBLById(int id);

        public bool DeleteSubjectBL(int SubjectId);


        public SubjectsBL<Subjects> SelectSubjectBLByName(string subjectBL);


        public List<SubjectsBL<Subjects>> SelectAllSubjectsBL();


        public bool SaveSubjectBL(SubjectsBL<Subjects> subjectBL);


       


        public List<SubjectsBL<Subjects>> FilterBySubjectBLName(List<SubjectsBL<Subjects>> subjectBLList, string filter);


        public bool UpdateSubjectBL(SubjectsBL<Subjects> subjectBLList);

        #endregion
    }
}
