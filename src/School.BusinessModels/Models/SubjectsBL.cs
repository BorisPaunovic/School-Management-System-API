using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModels.Models
{
    public class SubjectsBL
    {
        /*
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        public bool Deleted { get; set; }
        */
        public string Message { get; set; }
        public string Status { get; set; }
    }
    public class SubjectsBL<T> : SubjectsBL
    {
        public T Data { get; set; }
    }
}
