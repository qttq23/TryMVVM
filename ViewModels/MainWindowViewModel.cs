using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TryMVVM_SchoolManagement.Views;

namespace TryMVVM_SchoolManagement.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {

            StudentView = new StudentView();
            ClassesView = new ClassesView();
            TeacherView = new TeacherView();

            NavigateCommand = new MyICommand(OnNavigate, CanNavigate);
        }

        private UserControl studentView;
        public UserControl StudentView { get=>studentView;
            set
            {
                SetProperty(ref studentView, value);
            }
        }

        private UserControl classesView;
        public UserControl ClassesView
        {
            get => classesView;
            set
            {
                SetProperty(ref classesView, value);
            }
        }

        private UserControl teacherView;
        public UserControl TeacherView
        {
            get => teacherView;
            set
            {
                SetProperty(ref teacherView, value);
            }
        }


        private UserControl currentView;
        public UserControl CurrentView
        {
            get => currentView;
            set
            {
                SetProperty(ref currentView, value);
            }
        }

        public MyICommand NavigateCommand { get; set; }

        public void OnNavigate(Object parameter)
        {
            // get string parameter
            string choose = parameter as string;
            if (choose == null)
                return;

           

            // switch views
            if (choose == "Student")
            {
                CurrentView = StudentView;
            }
            else if (choose == "Teacher")
            {
                CurrentView = TeacherView;
            }
        }


        public bool CanNavigate(Object parameter)
        {
            return true;
        }
    }
}
