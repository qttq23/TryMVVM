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
    public class TeacherViewModel : BindableBase
    {
        public TeacherViewModel()
        {
            TeacherList = DataBase.TeacherList;
            CurrentTeacher = TeacherList[0];


        }


        public BindingList<Student> TeacherList { get; set; }

        private Student currentTeacher;
        public Student CurrentTeacher
        {
            get => currentTeacher;
            set
            {
                SetProperty(ref currentTeacher, value);
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
            foreach (var teacher in TeacherList)
            {
                if (teacher.ClassId == CurrentClass.Id)
                {
                    CurrentTeacher = teacher;
                    break;
                }
            }
        }
    }
}
