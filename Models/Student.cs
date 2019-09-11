using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TryMVVM_SchoolManagement.Models
{
    public class Student
    {

        private string id;
        public string Id
        {
            get => id;
            set
            {
                SetProperty(ref id, value);
            }
        }

        private string name;
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
        public string ClassId
        {
            get => classId;
            set
            {
                SetProperty(ref classId, value);
            }
        }


        protected virtual void SetProperty<T>(ref T member, T val,
           [CallerMemberName] string propertyName = null)
        {

            if (object.Equals(member, val)) return;

            member = val;
            
        }
    }
}
