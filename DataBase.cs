using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMVVM_SchoolManagement.Models;


namespace TryMVVM_SchoolManagement
{
    public static class DataBase
    {

        public static BindingList<Class> ClassList = new BindingList<Class>()
        {
            new Class() {Id="1", Name="Math" },
            new Class() {Id="2", Name="Physics" },
            new Class() {Id="3", Name="Chemistry" },
        };

        public static BindingList<Student> StudentList = new BindingList<Student>()
        {
            new Student()
            {
                Id = "1753102",
                Name = "Bui Thang",
                Age = 20,
                ClassId = "1",
            },

            new Student()
            {
                Id = "1753103",
                Name = "Bui Thang 2",
                Age = 20,
                ClassId = "2",
            },

            new Student()
            {
                Id = "1753104",
                Name = "Bui Thang 3",
                Age = 20,
                ClassId = "3",
            },
        };

        public static BindingList<Student> TeacherList = new BindingList<Student>()
        {
            new Student(){
                Id = "1001",
                Name = "Teacher 1",
                Age = 39,
                ClassId = "1",
            },
            new Student(){
                Id = "1002",
                Name = "Teacher 2",
                Age = 20,
                ClassId = "2",
            },
            new Student(){
                Id = "1003",
                Name = "Teacher 3",
                Age = 30,
                ClassId = "3",
            },
        };
    }
}
