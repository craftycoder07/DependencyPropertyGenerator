using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class MultiComboBoxModel : INotifyPropertyChanged
    {
        private string _enumValue;
        private bool _isChecked;
        public string EnumValue
        {
            set
            {
                _enumValue = value;
                NotifyPropertyChanged("EnumValue");
            }
            get
            {
                return _enumValue;
            }
        }
        public bool IsChecked
        {
            set
            {
                _isChecked = value;
                NotifyPropertyChanged("IsChecked");
            }
            get
            {
                return _isChecked;
            }
        }

        public MultiComboBoxModel(string enumValue)
        {
            EnumValue = enumValue;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
