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
                    GenerateDPPropertyMetadata(dependencyPropertyModel.RegisterMethod, dependencyPropertyModel.FrameworkPropertyMetadata);
                    break;
                case RegisterMethodOverload.WithPropertyMetadataAndCallback:
                    GenerateDPPropertyMetadataAndCallback(dependencyPropertyModel);
                    break;
                default:

                    break;
            }
        }

        private void GenerateDPBasic(RegisterMethodModel registerMethodModel)
        {
            //Step 1 -> Dependency property
            StringBuilder declarationDependencyProperty = new StringBuilder();
            declarationDependencyProperty.AppendLine("public static readonly DependencyProperty " + registerMethodModel.NameOfProperty + "Property;\n\n");

            //Step 2 -> Register DP
            StringBuilder registerDependencyProperty = new StringBuilder();
            registerDependencyProperty.Append("static " + registerMethodModel.OwnerOfProperty + "()\n{\n\t" + registerMethodModel.OwnerOfProperty + "." + registerMethodModel.NameOfProperty + "Property = DependencyProperty.Register(" + "\"" + registerMethodModel.NameOfProperty + "\", " + "typeof(" + registerMethodModel.TypeOfProperty + "), " + "typeof(" + registerMethodModel.OwnerOfProperty + "));\n}\n\n");

            //Step 3 -> Wrapper
            StringBuilder wrapperDependencyProperty = new StringBuilder();
            wrapperDependencyProperty.Append("public " + registerMethodModel.TypeOfProperty + " " + registerMethodModel.NameOfProperty + "\n{\n\t" + "get { return (" + registerMethodModel.TypeOfProperty + ")GetValue(" + registerMethodModel.OwnerOfProperty + "." + registerMethodModel.NameOfProperty + "Property);}\n\t" + "set { SetValue(" + registerMethodModel.OwnerOfProperty + "." + registerMethodModel.NameOfProperty + "Property, value); }\n}\n\n");

            tBDependencyProperty.Text = declarationDependencyProperty.ToString() + registerDependencyProperty.ToString() + wrapperDependencyProperty.ToString();

        }

        private void GenerateDPPropertyMetadata(RegisterMethodModel registerMethodModel, FrameworkPropertyMetadataModel frameworkPropertyMetadataModel)
        {
            //prepare FrameworkPropertyMetadata
            StringBuilder frameworkPropertyMetadata = new StringBuilder();

            FrameworkPropertyMetadataOverload selectedFrameworkOverload = frameworkPropertyMetadataModel.SelectedOverload;

            switch(selectedFrameworkOverload)
            {
                case FrameworkPropertyMetadataOverload.Basic:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata()");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValue:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata("+ frameworkPropertyMetadataModel.DefaultValue + ")");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOption:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.FrameworkPropertyMetadataOptions);

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChanged:
                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerce:
                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerceAnimation:
                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerceAnimationUpdateTrigger:
                    break;
                case FrameworkPropertyMetadataOverload.DefaultValuePropertyChanged:
                    break;
                case FrameworkPropertyMetadataOverload.DefaultValuePropertyChangedCoerce:
                    break;
                case FrameworkPropertyMetadataOverload.PropertyChanged:
                    break;
                case FrameworkPropertyMetadataOverload.PropertyChangedCoerce:
                    break;
            }
        }

        private void GenerateDPPropertyMetadataAndCallback(DependencyPropertyModel dependencyPropertyModel)
        {

        }

    }
}
