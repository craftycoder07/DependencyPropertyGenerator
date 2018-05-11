using Common;
using Common.Model;
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

namespace DependencyPropertyGenerator
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

        private void RegisterMethodOverloadControl_RegisterMethodOverload_SelectionChanged(RegisterMethodOverload selectedValue)
        {

            switch(selectedValue)
            {
                case RegisterMethodOverload.Basic:

                    FrameworkPropertyMetadataControl.Visibility = Visibility.Collapsed;
                    ValidationCallbackControl.Visibility = Visibility.Collapsed;

                    break;

                case RegisterMethodOverload.WithPropertyMetadata:

                    FrameworkPropertyMetadataControl.Visibility = Visibility.Visible;
                    ValidationCallbackControl.Visibility = Visibility.Collapsed;

                    break;

                case RegisterMethodOverload.WithPropertyMetadataAndCallback:

                    FrameworkPropertyMetadataControl.Visibility = Visibility.Visible;
                    ValidationCallbackControl.Visibility = Visibility.Visible;

                    break;
                default:

                    FrameworkPropertyMetadataControl.Visibility = Visibility.Visible;
                    ValidationCallbackControl.Visibility = Visibility.Visible;

                    break;
            }
        }

        private void btnGenerateDependencyProperty_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if(button.Content.Equals("Generate Dependency Property"))
            {
                UserControlPanel.Visibility = Visibility.Collapsed;
                OutputPanel.Visibility = Visibility.Visible;
                btnGenerateDependencyProperty.Content = "Back";
            }
            else
            {
                UserControlPanel.Visibility = Visibility.Visible;
                OutputPanel.Visibility = Visibility.Collapsed;
                btnGenerateDependencyProperty.Content = "Generate Dependency Property";
            }
        }

        private RegisterMethodModel GetInputData()
        {
            FrameworkPropertyMetadataModel frameworkPropertyMetadataModel = null;
            string validateValueCallbackName = string.Empty;
            RegisterMethodModel registerMethodModel = null;

            try
            {
                frameworkPropertyMetadataModel = FrameworkPropertyMetadataControl.GetControlValues();
                validateValueCallbackName = ValidationCallbackControl.GetControlValues();
                registerMethodModel = RegisterMethodOverloadControl.GetControlValues();

                registerMethodModel.FrameworkPropertyMetadata = frameworkPropertyMetadataModel;
                registerMethodModel.ValidateValueCallbackName = validateValueCallbackName;
            }
            catch(Exception e)
            {

            }

            return registerMethodModel;

        }
    }
}
