using System;
using System.Collections.Generic;
using System.Linq;
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
using TryMVVM_SchoolManagement.Services;
using TryMVVM_SchoolManagement.ViewModels;

namespace TryMVVM_SchoolManagement.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : UserControl
    {
        public MainWindowView()
        {
            InitializeComponent();

        }


        private void ButtonRemoveClass_Click(object sender, RoutedEventArgs e)
        {

            // this is a temporary solution
            // this method must be passed to particular view to handle, in fact.
            DataBase.ClassList.RemoveAt(0);
        }


        private Object GetViewModelInstance()
        {
            return ViewModelLocator.LocatedViewModelDictionary[
                        "TryMVVM_SchoolManagement.ViewModels.MainWindowViewModel"];
        }

    }
}
