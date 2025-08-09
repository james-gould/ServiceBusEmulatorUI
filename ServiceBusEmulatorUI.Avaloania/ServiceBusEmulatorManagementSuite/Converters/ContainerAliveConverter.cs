using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.UI.Converters
{
    public class ContainerAliveConverter : AbstractConverter<bool>
    {
        public override object ConvertBackwards(bool value, object? parameter)
        {
            return value ? "Online" : "Offline";
        }

        public override object ConvertForwards(bool value, object? parameter)
        {
            return value ? "Online" : "Offline";
        }
    }
}
