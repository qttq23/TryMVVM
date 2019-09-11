using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            
            //CurrentStudent = StudentList[0];
            SimpleEditableStudent newStudent = new SimpleEditableStudent();
            CopyStudent(StudentList[0], newStudent);
            CurrentStudent = newStudent;
            

        }


        public BindingList<Student> StudentList { get; set; }

        private SimpleEditableStudent currentStudent;
        public SimpleEditableStudent CurrentStudent
        {
            get => currentStudent;
            set
            {
                SetProperty(ref currentStudent, value);
            }

        }

        private void CopyStudent(Student source, SimpleEditableStudent dest)
        {
            if (source == null || dest == null)
                return;


            dest.Id = source.Id;
            dest.Name = source.Name;
            dest.Age = source.Age;
            dest.ClassId = source.ClassId;
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
                    SimpleEditableStudent newStudent = new SimpleEditableStudent();
                    CopyStudent(student, newStudent);
                    CurrentStudent = newStudent;
                    break;
                }
            }
        }
    }

    public class SimpleEditableStudent : ValidatableBindableBase
    {
        
        
        private string id;
        [Display(Name= "Student Identifier")]
        [Required]
        [StringLength(7)]
        public string Id
        {
            get => id;
            set
            {
                
                SetProperty(ref id, value);
            }
        }

        private string name;
        [StringLength(10)]
        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
            }
        }

        private int age;
        
        public int Age
        {
            get => age;
            set
            {
                SetProperty(ref age, value);
            }
        }

        private string classId;
        [Display(Name="Class Identifier")]
        [Required]
        [StringLength(2)]
        public string ClassId
        {
            get => classId;
            set
            {
                SetProperty(ref classId, value);
            }
        }


    }
}
