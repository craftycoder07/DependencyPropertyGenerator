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

namespace ProjectControls
{
    /// <summary>
    /// Interaction logic for DependencyPropertyControl.xaml
    /// </summary>
    public partial class DependencyPropertyControl : UserControl
    {
        public DependencyPropertyControl()
        {
            InitializeComponent();
        }

        public void GenerateDependencyProperty(DependencyPropertyModel dependencyPropertyModel)
        {
            RegisterMethodOverload selectedOverload = dependencyPropertyModel.RegisterMethod.SelectedOverload;

            switch(selectedOverload)
            {
                case RegisterMethodOverload.Basic:
                    GenerateDPBasic(dependencyPropertyModel.RegisterMethod);
                    break;
                case RegisterMethodOverload.WithPropertyMetadata:

                    break;
                case RegisterMethodOverload.WithPropertyMetadataAndCallback:

                    break;
                default:

                    break;
            }
        }

        private void GenerateDPBasic(RegisterMethodModel registerMethodModel)
        {
            
        }

        private void GenerateDPPropertyMetadata(RegisterMethodModel registerMethodModel, FrameworkPropertyMetadataModel frameworkPropertyMetadataModel)
        {

        }

        private void GenerateDPPropertyMetadataAndCallback(DependencyPropertyModel dependencyPropertyModel)
        {

        }

        
    }
}
