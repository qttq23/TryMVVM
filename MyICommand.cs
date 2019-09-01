using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TryMVVM
{
    public class MyICommand : ICommand
    {

        Action _TargetExecuteMethod;
        Func<bool> _TargetCanExecuteMethod;


        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }


        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            //MessageBox.Show("RaiseCanExecuteChanged");
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            //MessageBox.Show("CanExecute");
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            //MessageBox.Show("Execute");
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }


    }
}
