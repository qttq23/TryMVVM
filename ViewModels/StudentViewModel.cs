using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TryMVVM_SchoolManagement.Models;


namespace TryMVVM_SchoolManagement.ViewModels
{
    public class StudentViewModel : BindableBase
    {
        public StudentViewModel()
        {
            StudentList = DataBase.StudentList;
            CurrentStudent = StudentList[0];
        }


        public BindingList<Student> StudentList { get; set; }

        private Student currentStudent;
        public Student CurrentStudent
        {
            get => currentStudent;
            set
            {
                SetProperty(ref currentStudent, value);
            }
        }

        private Class currentClass;
        public Class CurrentClass
        {
            get => currentClass;
            set
            {
                if (currentClass == null || currentClass.Id != value.Id)
                {
                    currentClass = value;
                    RaiseClassChanged();
                }
            }
        }

        public void RaiseClassChanged()
        {
            // update student
            foreach (var student in StudentList)
            {
                if (student.ClassId == CurrentClass.Id)
                {
                    CurrentStudent = student;
                    break;
                }
            }
        }
    }
}
