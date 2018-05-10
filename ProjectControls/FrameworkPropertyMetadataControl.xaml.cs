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
    /// Interaction logic for FrameworkPropertyMetadataControl.xaml
    /// </summary>
    public partial class FrameworkPropertyMetadataControl : UserControl
    {
        public FrameworkPropertyMetadataControl()
        {
            InitializeComponent();
        }

        private void FrameworkProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if(comboBox.SelectedItem != null)
            {
                switch(comboBox.SelectedItem)
                {
                    case FrameworkPropertyMetadataOverload.Basic:

                        DefaultValue.Visibility = Visibility.Collapsed;
                        FrameworkMetadataOption.Visibility = Visibility.Collapsed;
                        PropertyChangedCallback.Visibility = Visibility.Collapsed;
                        CoerceValueCallback.Visibility = Visibility.Collapsed;
                        Animation.Visibility = Visibility.Collapsed;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    case FrameworkPropertyMetadataOverload.DefaultValue:

                        DefaultValue.Visibility = Visibility.Visible;
                        FrameworkMetadataOption.Visibility = Visibility.Collapsed;
                        PropertyChangedCallback.Visibility = Visibility.Collapsed;
                        CoerceValueCallback.Visibility = Visibility.Collapsed;
                        Animation.Visibility = Visibility.Collapsed;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    case FrameworkPropertyMetadataOverload.DefaultValueMetadataOption:

                        DefaultValue.Visibility = Visibility.Visible;
                        FrameworkMetadataOption.Visibility = Visibility.Visible;
                        PropertyChangedCallback.Visibility = Visibility.Collapsed;
                        CoerceValueCallback.Visibility = Visibility.Collapsed;
                        Animation.Visibility = Visibility.Collapsed;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChanged:

                        DefaultValue.Visibility = Visibility.Visible;
                        FrameworkMetadataOption.Visibility = Visibility.Visible;
                        PropertyChangedCallback.Visibility = Visibility.Visible;
                        CoerceValueCallback.Visibility = Visibility.Collapsed;
                        Animation.Visibility = Visibility.Collapsed;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerce:

                        DefaultValue.Visibility = Visibility.Visible;
                        FrameworkMetadataOption.Visibility = Visibility.Visible;
                        PropertyChangedCallback.Visibility = Visibility.Visible;
                        CoerceValueCallback.Visibility = Visibility.Visible;
                        Animation.Visibility = Visibility.Collapsed;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerceAnimation:

                        DefaultValue.Visibility = Visibility.Visible;
                        FrameworkMetadataOption.Visibility = Visibility.Visible;
                        PropertyChangedCallback.Visibility = Visibility.Visible;
                        CoerceValueCallback.Visibility = Visibility.Visible;
                        Animation.Visibility = Visibility.Visible;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    case FrameworkPropertyMetadataOverload.DefaultValueMetadataOptionPropertyChangedCoerceAnimationUpdateTrigger:

                        DefaultValue.Visibility = Visibility.Visible;
                        FrameworkMetadataOption.Visibility = Visibility.Visible;
                        PropertyChangedCallback.Visibility = Visibility.Visible;
                        CoerceValueCallback.Visibility = Visibility.Visible;
                        Animation.Visibility = Visibility.Visible;
                        UpdateSourceTrigger.Visibility = Visibility.Visible;

                        break;
                    case FrameworkPropertyMetadataOverload.DefaultValuePropertyChanged:

                        DefaultValue.Visibility = Visibility.Visible;
                        FrameworkMetadataOption.Visibility = Visibility.Collapsed;
                        PropertyChangedCallback.Visibility = Visibility.Visible;
                        CoerceValueCallback.Visibility = Visibility.Collapsed;
                        Animation.Visibility = Visibility.Collapsed;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    case FrameworkPropertyMetadataOverload.DefaultValuePropertyChangedCoerce:

                        DefaultValue.Visibility = Visibility.Visible;
                        FrameworkMetadataOption.Visibility = Visibility.Collapsed;
                        PropertyChangedCallback.Visibility = Visibility.Visible;
                        CoerceValueCallback.Visibility = Visibility.Visible;
                        Animation.Visibility = Visibility.Collapsed;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    case FrameworkPropertyMetadataOverload.PropertyChanged:

                        DefaultValue.Visibility = Visibility.Collapsed;
                        FrameworkMetadataOption.Visibility = Visibility.Collapsed;
                        PropertyChangedCallback.Visibility = Visibility.Visible;
                        CoerceValueCallback.Visibility = Visibility.Collapsed;
                        Animation.Visibility = Visibility.Collapsed;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    case FrameworkPropertyMetadataOverload.PropertyChangedCoerce:

                        DefaultValue.Visibility = Visibility.Collapsed;
                        FrameworkMetadataOption.Visibility = Visibility.Collapsed;
                        PropertyChangedCallback.Visibility = Visibility.Visible;
                        CoerceValueCallback.Visibility = Visibility.Visible;
                        Animation.Visibility = Visibility.Collapsed;
                        UpdateSourceTrigger.Visibility = Visibility.Collapsed;

                        break;
                    default:

                        DefaultValue.Visibility = Visibility.Visible;
                        FrameworkMetadataOption.Visibility = Visibility.Visible;
                        PropertyChangedCallback.Visibility = Visibility.Visible;
                        CoerceValueCallback.Visibility = Visibility.Visible;
                        Animation.Visibility = Visibility.Visible;
                        UpdateSourceTrigger.Visibility = Visibility.Visible;

                        break;
                }
            }
            
        }
    }
}
