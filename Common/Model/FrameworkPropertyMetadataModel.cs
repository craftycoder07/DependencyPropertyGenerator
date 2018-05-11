using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class FrameworkPropertyMetadataModel
    {
        public Object DefaultValue { set; get; }
        public Dictionary<string, Boolean> FrameworkPropertyMetadataOptions = new Dictionary<string, Boolean>();
        public BooleanEnum Animation { set; get; }
        public string PropertyChangedCallbackName { set; get; }
        public string CoerceValueCallbackName { set; get; }
        public UpdateSourceTrigger UpdateSourceTriggerName { set; get; }

        public FrameworkPropertyMetadataModel()
        {
            FrameworkPropertyMetadataOptions = Enum.GetNames(typeof(FrameworkPropertyMetadataOptions)).ToDictionary(key => key, value => false);
        }
    }
}
