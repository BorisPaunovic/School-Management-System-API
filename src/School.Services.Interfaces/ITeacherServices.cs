using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface ITeacherServices
    {
        public Teachers SelectTeacherByName(string TeacherName);
        public List<Teachers> SelectAllTeachers();


        public List<TeachersJoinCoursesResault> SelectAllTeachersJoinCourses();


        public bool SaveTeacher(Teachers teacher);




      

        public bool DeleteTeacher(int TeacherId);



        public bool UpdateTeacher(Teachers teacher);
        public Teachers SelectTeacherByID(int Id);
    }
}
