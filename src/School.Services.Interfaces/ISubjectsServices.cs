using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface ISubjectsServices
    {

        public List<Subjects> SelectAllSubjects();

        public bool SaveSubject(Subjects subject);

        public Subjects SelectSubjectByName(string subject);

        public bool DeleteSubject(int SubjectId);

        public bool UpdateSubject(Subjects subject);
        public Subjects SelectSubjectById(int Id);



    }
}
