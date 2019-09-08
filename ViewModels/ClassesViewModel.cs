using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TryMVVM_SchoolManagement.Models;
using TryMVVM_SchoolManagement.Services;

namespace TryMVVM_SchoolManagement.ViewModels
{
    public class ClassesViewModel
    {
        
        public ClassesViewModel()
        {
            LoadClasses();
        }

        public BindingList<Class> ClassList { get; set; }

        private Class selectedClass;
        public Class SelectedClass { get=>selectedClass;
            set
            {
                if (selectedClass == null || value.Id != selectedClass.Id)
                {
                    selectedClass = value;
                    RaiseClassChanged();
                }
            }
        }

        public void LoadClasses()
        {
            ClassList = DataBase.ClassList;
        }

        public void RaiseClassChanged()
        {
            // update student view
            var studentViewModel = 
                ViewModelLocator.LocatedViewModelDictionary["TryMVVM_SchoolManagement.ViewModels.StudentViewModel"] 
                as StudentViewModel;
            studentViewModel.CurrentClass = SelectedClass;

            // update teacher view
            var teacherViewModel =
                ViewModelLocator.LocatedViewModelDictionary["TryMVVM_SchoolManagement.ViewModels.TeacherViewModel"]
                as TeacherViewModel;
            teacherViewModel.CurrentClass = SelectedClass;

        }
    }
}
