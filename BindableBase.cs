using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TryMVVM_SchoolManagement
{
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


    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private object _lock = new object();
        public bool HasErrors
        {
            get
            {
                //MessageBox.Show("HasErrors");
                return _errors.Any(propErrors => propErrors.Value != null && propErrors.Value.Count > 0);
            }
        }

        //public bool IsValid { get { return this.HasErrors; } }

        public IEnumerable GetErrors(string propertyName)
        {
            //MessageBox.Show("GetErrors");
            if (!string.IsNullOrEmpty(propertyName))
            {
                if (_errors.ContainsKey(propertyName)
                    && (_errors[propertyName] != null)
                    && _errors[propertyName].Count > 0)
                    return _errors[propertyName].ToList();
                else
                    return null;
            }
            else
                return _errors.SelectMany(err => err.Value.ToList());
        }

        public void OnErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void ValidateProperty(object value, [CallerMemberName] string propertyName = null)
        {
            //MessageBox.Show("Validate Property");
            lock (_lock)
            {
                var validationContext = new ValidationContext(this, null, null);
                validationContext.MemberName = propertyName;
                var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                Validator.TryValidateProperty(value, validationContext, validationResults);

                //clear previous _errors from tested property  
                if (_errors.ContainsKey(propertyName))
                    _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
                HandleValidationResults(validationResults);
            }
        }

        //public void Validate()
        //{
        //    lock (_lock)
        //    {
        //        var validationContext = new ValidationContext(this, null, null);
        //        var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
        //        Validator.TryValidateObject(this, validationContext, validationResults, true);

        //        //clear all previous _errors  
        //        var propNames = _errors.Keys.ToList();
        //        _errors.Clear();
        //        propNames.ForEach(pn => OnErrorsChanged(pn));
        //        HandleValidationResults(validationResults);
        //    }
        //}

        private void HandleValidationResults(
            List<System.ComponentModel.DataAnnotations.ValidationResult> validationResults)
        {
            //Group validation results by property names  
            var resultsByPropNames = from res in validationResults
                                     from mname in res.MemberNames
                                     group res by mname into g
                                     select g;
            //add _errors to dictionary and inform binding engine about _errors  
            foreach (var prop in resultsByPropNames)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();
                _errors.Add(prop.Key, messages);
                OnErrorsChanged(prop.Key);
            }
        }

        override protected void SetProperty<T>(ref T member, T val,
           [CallerMemberName] string propertyName = null)
        {
            member = val;
            //base.SetProperty(ref member, val, propertyName);
            ValidateProperty(val, propertyName);
            OnPropertyChanged(propertyName);

            //MessageBox.Show(HasErrors.ToString());
        }
    }
}
