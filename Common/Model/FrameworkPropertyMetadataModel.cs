using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class FrameworkPropertyMetadataModel
    {
        public FrameworkPropertyMetadataOverload SelectedOverload { set; get; }
        public Object DefaultValue { set; get; }
        public Dictionary<string, object> FrameworkPropertyMetadataOptions = new Dictionary<string, object>();
        public BooleanEnum Animation { set; get; }
        public string PropertyChangedCallbackName { set; get; }
        public string CoerceValueCallbackName { set; get; }
        public UpdateSourceTrigger UpdateSourceTriggerName { set; get; }
    }
}
