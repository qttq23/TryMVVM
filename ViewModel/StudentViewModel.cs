using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TryMVVM.Model;

namespace TryMVVM.ViewModel
{
    class StudentViewModel
    {
        public StudentViewModel()
        {
            LoadStudents();
        }

        public ObservableCollection<Student> Students { get; set; }

        public void LoadStudents()
        {
            var someNewStudents = new ObservableCollection<Student>()
            {
                new Student(){FirstName="Bui", LastName="Thang"},
                new Student(){FirstName="Irous", LastName="Quang"},
                new Student(){FirstName="Mr", LastName="Irous"},
            };

            Students = someNewStudents;
        }

    }
}
