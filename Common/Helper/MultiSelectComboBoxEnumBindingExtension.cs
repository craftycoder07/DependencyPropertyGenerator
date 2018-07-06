using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Common.Helper
{
    public class MultiSelectComboBoxEnumBindingExtension : MarkupExtension
    {
        private Type _enumType;
        public Type EnumType
        {
            get { return _enumType; }
            set
            {
                if (value != _enumType)
                {
                    if (null != value)
                    {
                        Type enumType = Nullable.GetUnderlyingType(value) ?? value;
                        if (!enumType.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    _enumType = value;
                }
            }
        }

        private Type _multiSelectModel;
        public Type MultiSelectModel
        {
            get { return _multiSelectModel; }
            set
            {
                if(value != _multiSelectModel)
                {
                    _multiSelectModel = value;
                }
            }
        }

        public MultiSelectComboBoxEnumBindingExtension() { }

        public MultiSelectComboBoxEnumBindingExtension(Type enumType, Type multiSelectModel)
        {
            EnumType = enumType;
            MultiSelectModel = multiSelectModel;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == _enumType)
                throw new InvalidOperationException("The EnumType must be specified.");

            if(null == _multiSelectModel)
                throw new InvalidOperationException("The MultiSelectComboBoxModel must be specified.");

            Type actualEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;
            Array enumValues = Enum.GetValues(actualEnumType);

            Type genericListType = typeof(List<>).MakeGenericType(_multiSelectModel);
            IList finalList = (IList)Activator.CreateInstance(genericListType);

            foreach(var enumValue in enumValues)
            {
                finalList.Add(Activator.CreateInstance(_multiSelectModel, new object[] { enumValue.ToString(), false}));
            }
            //if (actualEnumType == _enumType)
            //    return finalList;

            //Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            //enumValues.CopyTo(tempArray, 1);
            //return tempArray;

            return finalList;
        }
    }
}
