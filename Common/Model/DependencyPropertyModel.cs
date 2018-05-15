using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class DependencyPropertyModel
    {
        public RegisterMethodModel RegisterMethod { set; get; }
        public FrameworkPropertyMetadataModel FrameworkPropertyMetadata { set; get; }
        public string ValidateValueCallbackName { set; get; }
    }
}
