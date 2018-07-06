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
    /// Interaction logic for MultiSelectComboBox.xaml
    /// </summary>
    public partial class MultiSelectComboBox : UserControl
    {
        public MultiSelectComboBox()
        {
            InitializeComponent();
        }

        #region Dependency Properties

        /// <summary>

        ///Gets or sets a collection used to generate the content of the ComboBox

        /// </summary>

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(object), typeof(MultiSelectComboBox), new UIPropertyMetadata(null));

        public object ItemsSource
        {
            get{ return(object) GetValue(ItemsSourceProperty);}
            set
            {
                SetValue(ItemsSourceProperty, value);
                SetText();
            }
        }

        /// <summary>

        ///Gets or sets the text displayed in the ComboBox

        /// </summary>

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MultiSelectComboBox), new UIPropertyMetadata(string.Empty));

        public string Text
        {
            get{ return(string) GetValue(TextProperty); }
            set{ SetValue(TextProperty, value); }

        }

        
        /// <summary>

        ///Gets or sets the text displayed in the ComboBox if there are no selected items

        /// </summary>

        public static readonly DependencyProperty DefaultTextProperty = DependencyProperty.Register("DefaultText", typeof(string), typeof(MultiSelectComboBox), new UIPropertyMetadata(string.Empty));

        public string DefaultText
        {
            get{ return(string) GetValue(DefaultTextProperty); }
            set{ SetValue(DefaultTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DefaultText.  This enables animation, styling, binding, etc…

       
        #endregion

        /// <summary>

        ///Whenever a CheckBox is checked, change the text displayed

        /// </summary>

        /// <param name="sender"></param>

        /// <param name="e"></param>

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            SetText();
        }

        /// <summary>

        ///Set the text property of this control (bound to the ContentPresenter of the ComboBox)

        /// </summary>

        private void SetText()
        {
            this.Text = (this.ItemsSource != null) ? this.ItemsSource.ToString() : this.DefaultText;

            // set DefaultText if nothing else selected
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.DefaultText;
            }
        }
    }
}
