using Common;
using Common.Helper;
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
            #region Prepare FrameworkPropertyMetadata

            StringBuilder frameworkPropertyMetadata = new StringBuilder();

            FrameworkPropertyMetadataOverload selectedFrameworkOverload = frameworkPropertyMetadataModel.SelectedOverload;
            string _frameworkPropertyMetadataOptionsText = getMetadataOptions(frameworkPropertyMetadataModel.FrameworkPropertyMetadataOptions);
            string separator = ", ";

            switch (selectedFrameworkOverload)
            {
                case FrameworkPropertyMetadataOverload.Basic:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata()");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValue:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata("+ frameworkPropertyMetadataModel.DefaultValue + ")");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOption:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + ")");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChanged:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + "))");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerce:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback("+ frameworkPropertyMetadataModel.CoerceValueCallbackName+ "))");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerceAnimation:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback(" + frameworkPropertyMetadataModel.CoerceValueCallbackName + ")" + separator + frameworkPropertyMetadataModel.Animation+ ")");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerceAnimationUpdateTrigger:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback(" + frameworkPropertyMetadataModel.CoerceValueCallbackName + ")" + separator + frameworkPropertyMetadataModel.Animation + separator + "UpdateSourceTrigger." + frameworkPropertyMetadataModel.UpdateSourceTriggerName + ")");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValuePropertyChanged:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + "))");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValuePropertyChangedCoerce:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback(" + frameworkPropertyMetadataModel.CoerceValueCallbackName + "))");

                    break;
                case FrameworkPropertyMetadataOverload.PropertyChanged:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + "))");

                    break;
                case FrameworkPropertyMetadataOverload.PropertyChangedCoerce:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback(" + frameworkPropertyMetadataModel.CoerceValueCallbackName + "))");

                    break;
            }

            #endregion

            //Step 1 -> Dependency property
            StringBuilder declarationDependencyProperty = new StringBuilder();
            declarationDependencyProperty.AppendLine("public static readonly DependencyProperty " + registerMethodModel.NameOfProperty + "Property;\n\n");

            //Step 2 -> Register DP
            StringBuilder registerDependencyProperty = new StringBuilder();
            registerDependencyProperty.Append("static " + registerMethodModel.OwnerOfProperty + "()\n{\n\t" + registerMethodModel.OwnerOfProperty + "." + registerMethodModel.NameOfProperty + "Property = DependencyProperty.Register(" + "\"" + registerMethodModel.NameOfProperty + "\", " + "typeof(" + registerMethodModel.TypeOfProperty + "), " + "typeof(" + registerMethodModel.OwnerOfProperty + "),\n\t" + frameworkPropertyMetadata + ");\n}\n\n");

            //Step 3 -> Wrapper
            StringBuilder wrapperDependencyProperty = new StringBuilder();
            wrapperDependencyProperty.Append("public " + registerMethodModel.TypeOfProperty + " " + registerMethodModel.NameOfProperty + "\n{\n\t" + "get { return (" + registerMethodModel.TypeOfProperty + ")GetValue(" + registerMethodModel.OwnerOfProperty + "." + registerMethodModel.NameOfProperty + "Property);}\n\t" + "set { SetValue(" + registerMethodModel.OwnerOfProperty + "." + registerMethodModel.NameOfProperty + "Property, value); }\n}\n\n");


            //Step 4 - > Callbacks
            StringBuilder dependencyPropertyCallbacks = new StringBuilder();
            if(!string.IsNullOrEmpty(frameworkPropertyMetadataModel.PropertyChangedCallbackName))
            {
                dependencyPropertyCallbacks.Append("private static void " + frameworkPropertyMetadataModel.PropertyChangedCallbackName + "(DependencyObject o, DependencyPropertyChangedEventArgs e)\n{\n\n}\n\n");
            }

            if(!string.IsNullOrEmpty(frameworkPropertyMetadataModel.CoerceValueCallbackName))
            {
                dependencyPropertyCallbacks.Append("private static void " + frameworkPropertyMetadataModel.CoerceValueCallbackName + "(DependencyObject d, object value)\n{\n\n}\n\n");
            }

            tBDependencyProperty.Text = declarationDependencyProperty.ToString() + registerDependencyProperty.ToString() + wrapperDependencyProperty.ToString() + dependencyPropertyCallbacks.ToString();
        }

        private void GenerateDPPropertyMetadataAndCallback(DependencyPropertyModel dependencyPropertyModel)
        {
            RegisterMethodModel registerMethodModel = dependencyPropertyModel.RegisterMethod;
            FrameworkPropertyMetadataModel frameworkPropertyMetadataModel = dependencyPropertyModel.FrameworkPropertyMetadata;


            #region Prepare FrameworkPropertyMetadata

            StringBuilder frameworkPropertyMetadata = new StringBuilder();

            FrameworkPropertyMetadataOverload selectedFrameworkOverload = frameworkPropertyMetadataModel.SelectedOverload;
            string _frameworkPropertyMetadataOptionsText = getMetadataOptions(frameworkPropertyMetadataModel.FrameworkPropertyMetadataOptions);
            string separator = ", ";

            switch (selectedFrameworkOverload)
            {
                case FrameworkPropertyMetadataOverload.Basic:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata()");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValue:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + ")");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOption:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + ")");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChanged:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + "))");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerce:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback(" + frameworkPropertyMetadataModel.CoerceValueCallbackName + "))");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerceAnimation:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback(" + frameworkPropertyMetadataModel.CoerceValueCallbackName + ")" + separator + frameworkPropertyMetadataModel.Animation + ")");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerceAnimationUpdateTrigger:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + _frameworkPropertyMetadataOptionsText + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback(" + frameworkPropertyMetadataModel.CoerceValueCallbackName + ")" + separator + frameworkPropertyMetadataModel.Animation + separator + "UpdateSourceTrigger." + frameworkPropertyMetadataModel.UpdateSourceTriggerName + ")");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValuePropertyChanged:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + "))");

                    break;
                case FrameworkPropertyMetadataOverload.DefaultValuePropertyChangedCoerce:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(" + frameworkPropertyMetadataModel.DefaultValue + separator + "new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback(" + frameworkPropertyMetadataModel.CoerceValueCallbackName + "))");

                    break;
                case FrameworkPropertyMetadataOverload.PropertyChanged:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + "))");

                    break;
                case FrameworkPropertyMetadataOverload.PropertyChangedCoerce:

                    frameworkPropertyMetadata.Append("FrameworkPropertyMetadata(new PropertyChangedCallback(" + frameworkPropertyMetadataModel.PropertyChangedCallbackName + ")" + separator + "new CoerceValueCallback(" + frameworkPropertyMetadataModel.CoerceValueCallbackName + "))");

                    break;
            }

            #endregion

            //Step 1 -> Dependency property
            StringBuilder declarationDependencyProperty = new StringBuilder();
            declarationDependencyProperty.AppendLine("public static readonly DependencyProperty " + registerMethodModel.NameOfProperty + "Property;\n\n");

            //Step 2 -> Register DP
            StringBuilder registerDependencyProperty = new StringBuilder();
            registerDependencyProperty.Append("static " + registerMethodModel.OwnerOfProperty + "()\n{\n\t" + registerMethodModel.OwnerOfProperty + "." + registerMethodModel.NameOfProperty + "Property = DependencyProperty.Register(" + "\"" + registerMethodModel.NameOfProperty + "\", " + "typeof(" + registerMethodModel.TypeOfProperty + "), " + "typeof(" + registerMethodModel.OwnerOfProperty + "),\n\t" + frameworkPropertyMetadata + ",\n\t" + "new ValidationValueCallback(" + dependencyPropertyModel.ValidateValueCallbackName +"));\n}\n\n");

            //Step 3 -> Wrapper
            StringBuilder wrapperDependencyProperty = new StringBuilder();
            wrapperDependencyProperty.Append("public " + registerMethodModel.TypeOfProperty + " " + registerMethodModel.NameOfProperty + "\n{\n\t" + "get { return (" + registerMethodModel.TypeOfProperty + ")GetValue(" + registerMethodModel.OwnerOfProperty + "." + registerMethodModel.NameOfProperty + "Property);}\n\t" + "set { SetValue(" + registerMethodModel.OwnerOfProperty + "." + registerMethodModel.NameOfProperty + "Property, value); }\n}\n\n");

            //Step 4 - > Callbacks
            StringBuilder dependencyPropertyCallbacks = new StringBuilder();
            if (!string.IsNullOrEmpty(frameworkPropertyMetadataModel.PropertyChangedCallbackName))
            {
                dependencyPropertyCallbacks.Append("private static void " + frameworkPropertyMetadataModel.PropertyChangedCallbackName + "(DependencyObject o, DependencyPropertyChangedEventArgs e)\n{\n\n}\n\n");
            }

            if (!string.IsNullOrEmpty(frameworkPropertyMetadataModel.CoerceValueCallbackName))
            {
                dependencyPropertyCallbacks.Append("private static void " + frameworkPropertyMetadataModel.CoerceValueCallbackName + "(DependencyObject d, object value)\n{\n\n}\n\n");
            }

            if(!string.IsNullOrEmpty(dependencyPropertyModel.ValidateValueCallbackName))
            {
                dependencyPropertyCallbacks.Append("private static void " + dependencyPropertyModel.ValidateValueCallbackName + "(object value)\n{\n\n}\n\n");
            }

            tBDependencyProperty.Text = declarationDependencyProperty.ToString() + registerDependencyProperty.ToString() + wrapperDependencyProperty.ToString() + dependencyPropertyCallbacks.ToString();
        }

        private string getMetadataOptions(Dictionary<string, object> _frameworkPropertyMetadataOptions)
        {
            StringBuilder _frameworkPropertyMetadataOptionsText = new StringBuilder();
            string prefix = "FrameworkPropertyMetadataOptions.";
            string finalAns = string.Empty;
            if (_frameworkPropertyMetadataOptions != null)
            {
                _frameworkPropertyMetadataOptionsText.Append("(");
                foreach (KeyValuePair<string, object> s in _frameworkPropertyMetadataOptions)
                {
                    string ans = prefix + s.Key + " | ";
                    _frameworkPropertyMetadataOptionsText.Append(ans);
                }
                finalAns =_frameworkPropertyMetadataOptionsText.ToString().TrimEndString(" | ");
                finalAns = finalAns + ")";
            }

            return finalAns;
        }
    }
}
