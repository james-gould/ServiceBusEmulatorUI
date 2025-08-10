using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.UI.Converters
{
    public class BackgroundColourConverter : AbstractConverter<bool>
    {

        public override object ConvertForwards(bool value, object? parameter)
        {
            return value ? "Azure" : "Red";
        }

        public override object ConvertBackwards(bool value, object? parameter)
        {
            return value ? "Azure" : "red";
        }
    }
}
