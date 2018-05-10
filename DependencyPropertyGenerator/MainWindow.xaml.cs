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

        private void RegisterMethodOverloadControl_RegisterMethodOverload_SelectionChanged(ProjectControls.RegisterMethodOverload selectedValue)
        {

            switch(selectedValue)
            {
                case ProjectControls.RegisterMethodOverload.Basic:

                    FrameworkPropertyMetadataControl.Visibility = Visibility.Collapsed;
                    ValidationCallbackControl.Visibility = Visibility.Collapsed;

                    break;

                case ProjectControls.RegisterMethodOverload.WithPropertyMetadata:

                    FrameworkPropertyMetadataControl.Visibility = Visibility.Visible;
                    ValidationCallbackControl.Visibility = Visibility.Collapsed;

                    break;

                case ProjectControls.RegisterMethodOverload.WithPropertyMetadataAndCallback:

                    FrameworkPropertyMetadataControl.Visibility = Visibility.Visible;
                    ValidationCallbackControl.Visibility = Visibility.Visible;

                    break;
                default:

                    FrameworkPropertyMetadataControl.Visibility = Visibility.Visible;
                    ValidationCallbackControl.Visibility = Visibility.Visible;

                    break;
            }
        }
    }
}
