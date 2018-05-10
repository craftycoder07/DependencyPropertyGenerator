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

namespace ProjectControls
{
    /// <summary>
    /// Interaction logic for RegisterMethodOverloadControl.xaml
    /// </summary>
    public partial class RegisterMethodOverloadControl : UserControl
    {
        public delegate void RegisterMethodOverloadSelectionChangedHandler(RegisterMethodOverload selectedValue);

        public event RegisterMethodOverloadSelectionChangedHandler RegisterMethodOverload_SelectionChanged;

        public RegisterMethodOverloadControl()
        {
            InitializeComponent();
        }

        private void RegisterMethodOverloadComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedItem != null)
            {
                RegisterMethodOverload_SelectionChanged((RegisterMethodOverload)comboBox.SelectedItem);
            }
        }
    }
}
