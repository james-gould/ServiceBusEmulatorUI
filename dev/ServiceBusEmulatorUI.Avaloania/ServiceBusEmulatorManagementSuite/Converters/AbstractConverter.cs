using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.UI.Converters
{
    public abstract class AbstractConverter<TBaseType> : IValueConverter where TBaseType : struct
    {
        public object? Convert(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
        {
            EnsureHasValue(value);

            var mapped = (TBaseType)value!;

            return ConvertForwards(mapped, parameter);
        }

        public object? ConvertBack(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
        {
            EnsureHasValue(value);

            var mapped = (TBaseType)value!;

            return ConvertBackwards(mapped, parameter);
        }

        private void EnsureHasValue(object? value)
        {
            if (value is null)
                throw new ArgumentException($"Value was null when executing converter");
        }

        public abstract object ConvertForwards(TBaseType value, object? parameter);
        public abstract object ConvertBackwards(TBaseType value, object? parameter);
    }
}
