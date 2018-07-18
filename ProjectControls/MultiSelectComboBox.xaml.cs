using Common.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<MultiComboBoxModel> _comboBoxModelList;

        public MultiSelectComboBox()
        {
            InitializeComponent();
            _comboBoxModelList = new ObservableCollection<MultiComboBoxModel>();
        }

        #region Dependency Properties

        /// <summary>

        ///Gets or sets a collection used to generate the content of the ComboBox

        /// </summary>

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(Dictionary<string, object>), typeof(MultiSelectComboBox), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(MultiSelectComboBox.OnItemsSourceChanged)));

        public Dictionary<string, object> ItemsSource
        {
            get{ return(Dictionary<string, object>) GetValue(ItemsSourceProperty);}
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(Dictionary<string, object>), typeof(MultiSelectComboBox), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(MultiSelectComboBox.OnSelectedItemsChanged)));

        public Dictionary<string, object> SelectedItems
        {
            get { return (Dictionary<string, object>)GetValue(SelectedItemsProperty); }
            set
            {
                SetValue(SelectedItemsProperty, value);
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
            CheckBox clickedBox = (CheckBox)sender;
            
            if(SelectedItems == null)
            {
                SelectedItems = new Dictionary<string, object>();
            }

            SelectedItems.Clear();
            foreach(MultiComboBoxModel s in _comboBoxModelList)
            {
                if(s.IsChecked)
                {
                    if (ItemsSource.Count > 0)
                        SelectedItems.Add(s.EnumValue, ItemsSource[s.EnumValue]);
                }
            }

            SetText();
        }

        /// <summary>

        ///Set the text property of this control (bound to the ContentPresenter of the ComboBox)

        /// </summary>

        private void SetText()
        {
            if(SelectedItems != null)
            {
                StringBuilder _displayText = new StringBuilder();
                foreach(MultiComboBoxModel s in _comboBoxModelList)
                {
                    if(s.IsChecked)
                    {
                        _displayText.Append(s.EnumValue);
                        _displayText.Append(',');
                    }
                }
                Text = _displayText.ToString().TrimEnd(new char[] { ',' });
            }
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.DefaultText;
            }
        }

        private void DisplayEnumInControl()
        {
            _comboBoxModelList.Clear();
            foreach(KeyValuePair<string, object> _keyValue in ItemsSource)
            {
                MultiComboBoxModel multiComboBoxModel = new MultiComboBoxModel(_keyValue.Key);
                _comboBoxModelList.Add(multiComboBoxModel);
            }
            CheckableCombo.ItemsSource = _comboBoxModelList;
        }

        private void SelectNodes()
        {
            foreach (KeyValuePair<string, object> keyValue in SelectedItems)
            {
                MultiComboBoxModel s = _comboBoxModelList.FirstOrDefault(i => i.EnumValue == keyValue.Key);

                if (s != null)
                    s.IsChecked = true;
            }

        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox control = (MultiSelectComboBox)d;
            control.DisplayEnumInControl();
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox control = (MultiSelectComboBox)d;
            control.SelectNodes();
            control.SetText();
        }
    }
}
