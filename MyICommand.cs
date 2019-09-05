using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TryMVVM
{
    public class MyICommand<T> : ICommand
    {

        Action<T> _TargetExecuteMethod;
        Func<T, bool> _TargetCanExecuteMethod;


        public MyICommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public MyICommand(Action<T> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            //MessageBox.Show("RaiseCanExecuteChanged");
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            //MessageBox.Show(parameter.ToString());
            if (_TargetCanExecuteMethod != null)
            {
                var tParam = (T)parameter;
                return _TargetCanExecuteMethod(tParam);
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
           
            if (_TargetExecuteMethod != null)
            {
                var tParam = (T)parameter;
                _TargetExecuteMethod(tParam);
            }
        }


    }
}
