using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using Microsoft.Extensions.Configuration;
using School.Services.Interfaces;
using System.Xml.Linq;

namespace School.Services
{
    public class SubjectsServices: ISubjectsServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public SubjectsServices(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration.GetConnectionString("School-APIDbConnection");
        }
        public  List<Subjects> SelectAllSubjects()
        {
            List<Subjects> subjects = new List<Subjects>();
            try
            {
                string StoredProcedure = "SelectAllSubjects";
             //   string query = "   select SubjectID,SubjectName,SubjectDescription from Subjects ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    subjects = SqlConn.Query<Subjects>(StoredProcedure, commandType: CommandType.StoredProcedure).ToList();
                }


            }
            catch
            {

            }
            return subjects;
        }
        public  bool SaveSubject(Subjects subject)
        {
            bool IsSubjectsSaved = false;
            string StoredProcedure = "SaveSubject";
         //   string query = "insert into Subjects(SubjectName,SubjectDescription) values(@SubjectName,@SubjectDescription)";
            try
            {
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @SubjectName = subject.SubjectName, @SubjectDescription = subject.SubjectDescription }, commandType: CommandType.StoredProcedure);
                    IsSubjectsSaved = true;
                }
            }
            catch
            {
                IsSubjectsSaved = false;
            }
            return IsSubjectsSaved;
        }
        public  Subjects SelectSubjectByName(string subject)
        {
            Subjects subjects = new Subjects();
            try
            {
                string StoredProcedure = "SelectSubjectByName";
              //  string query = "  select SubjectID,SubjectDescription,SubjectName from Subjects where SubjectName=@SubjectName";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    subjects = SqlConn.QueryFirst<Subjects>(StoredProcedure, new { @SubjectName = subject }, commandType: CommandType.StoredProcedure);
                }


            }
            catch
            {

            }
            return subjects;
        }
        public  bool DeleteSubject(int SubjectId)
        {
            bool SubjectIsDeleted = false;
            int affectedRows = 0;

            try
            {
                string StoredProcedure = "DeleteSubject";
             //   string query = "delete Subjects where SubjectID=@SubjectId";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    affectedRows = SqlConn.Execute(StoredProcedure, new { @SubjectId = SubjectId }, commandType: CommandType.StoredProcedure);
                    if (affectedRows != 0)
                    {
                        SubjectIsDeleted = true;
                    }
                }

            }
            catch
            {
                if (affectedRows == 0)
                {
                    SubjectIsDeleted = false;
                }
            }
            return SubjectIsDeleted;







        }
        public  bool UpdateSubject(Subjects subject)
        {
            bool IsCourseUpdated = false;
            try
            {
                string StoredProcedure = "UpdateSubject";
               // string queery = "update Subjects set SubjectName=@SubjectName,SubjectDescription=@SubjectDescription where SubjectID=@SubjectID ";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    SqlConn.Execute(StoredProcedure, new { @SubjectName = subject.SubjectName, @SubjectDescription = subject.SubjectDescription, @SubjectID = subject.SubjectId }, commandType: CommandType.StoredProcedure);
                    IsCourseUpdated = true;
                }
            }
            catch
            {
                IsCourseUpdated = false;
            }
            return IsCourseUpdated;
        }

        public Subjects SelectSubjectById(int Id)
        {
            Subjects subjects = new Subjects();
            try
            {
                string StoredProcedure = "SelectSubjectById";
                //  string query = "  select SubjectID,SubjectDescription,SubjectName from Subjects where SubjectName=@SubjectName";
                using (SqlConnection SqlConn = new SqlConnection(_connectionString))
                {
                    subjects = SqlConn.QueryFirst<Subjects>(StoredProcedure, new { @SubjectId = Id }, commandType: CommandType.StoredProcedure);
                }


            }
            catch
            {

            }
            return subjects;
        }
    }
}
