using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyPropertyGenerator.Model
{
    class RegisterMethodModel
    {
        public string NameOfProperty { set; get; }
        public string TypeOfProperty { set; get; }
        public string OwnerOfProperty { set; get; }
        public FrameworkPropertyMetadataModel FrameworkPropertyMetadata { set; get; }
        public string ValidateValueCallbackName { set; get; }
    }
}
