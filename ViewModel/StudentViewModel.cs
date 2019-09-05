﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TryMVVM.Model;

namespace TryMVVM.ViewModel
{
    class StudentViewModel
    {
        public StudentViewModel()
        {
            LoadStudents();

            DeleteCommand = new MyICommand<Object>(OnDelete, CanDelete);
            CloneCommand = new MyICommand<Object>(OnClone, CanClone);
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

        public MyICommand<Object> DeleteCommand { get; set; }


        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }

            set
            {
                _selectedStudent = value;
                DeleteCommand.RaiseCanExecuteChanged();
                CloneCommand.RaiseCanExecuteChanged();
            }
        }


        private void OnDelete(Object parameter)
        {
            //MessageBox.Show("OnDelete");
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete(Object parameter)
        {
            //MessageBox.Show("CanDelete");
            return (SelectedStudent != null);
        }


        public MyICommand<Object> CloneCommand { get; set; }

        private void OnClone(Object parameter)
        {
            var newStudent = new Student() {
                FirstName = SelectedStudent.FirstName,
                LastName = SelectedStudent.LastName + "(clone)" };

            Students.Add(newStudent);
        }

        private bool CanClone(Object parameter)
        {
            return (SelectedStudent != null);
        }

    }

}
