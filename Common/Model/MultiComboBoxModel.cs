using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class MultiComboBoxModel
    {
        public string EnumValue { set; get; }
        public bool IsChecked { set; get; }

        public MultiComboBoxModel(string enumValue, bool isChecked)
        {
            EnumValue = enumValue;
            IsChecked = isChecked;
        }
    }
}
