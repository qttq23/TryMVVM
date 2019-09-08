using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TryMVVM_SchoolManagement
{
    public class MyICommand: ICommand
    {

        Action<Object> _TargetExecuteMethod;
        Func<Object, bool> _TargetCanExecuteMethod;


        public MyICommand(Action<Object> executeMethod, Func<Object, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public MyICommand(Action<Object> executeMethod)
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
                //var tParam = (T)parameter;
                return _TargetCanExecuteMethod(parameter);
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
                //var tParam = (T)parameter;
                _TargetExecuteMethod(parameter);
            }
        }


    }
}
