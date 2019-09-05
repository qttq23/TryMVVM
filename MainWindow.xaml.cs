using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TryMVVM.ViewModel;

namespace TryMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

    }

    public class MainWindowView : BindableBase
    {
        public MainWindowView()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        public MyICommand<string> NavCommand { get; private set; }

        private UserControl _currentView;
        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                SetProperty(ref _currentView, value);
            }
        }

        public UserControl studentView { get; set; }
        public UserControl teacherView { get; set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "students":
                    if (studentView == null)
                    {
                        studentView = new TryMVVM.View.StudentView();
                    }
                    CurrentView = studentView;
                    //ControlGrid.Children.Add(studentView);

                    break;

                case "teachers":
                default:
                    if (teacherView == null)
                    {
                        teacherView = new TryMVVM.View.TeacherView();
                    }

                    CurrentView = teacherView;
                    //ControlGrid.Children.Add(teacherView);

                    break;
            }
        }

    }
    public class BindableBase : INotifyPropertyChanged
    {

        protected virtual void SetProperty<T>(ref T member, T val,
           [CallerMemberName] string propertyName = null)
        {
            
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }

    
}
