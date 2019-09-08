using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMVVM_SchoolManagement.Models
{
    public class Student
    {
        private string id;
        public string Id { get; set; }

        private string name;
        public string Name { get; set; }

        private int age;
        public int Age { get; set; }

        private string classId;
        public string ClassId {get;set;}
    }
}
