using SBEManagementSuite.UI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Tests.ConverterTests
{
    [Collection(nameof(BackgroundColourConverterTests))]
    public class BackgroundColourConverterTests
    {
        public BackgroundColourConverter converter;
        public BackgroundColourConverterTests() 
        {
            converter = new BackgroundColourConverter();
        }
        
        [Theory]
        [InlineData(true, "Azure")]
        [InlineData(false, "Red")]
        public void BackgroundColourConverterTest(bool value, string expected)
        {
            var result = converter.Convert(value);

            Assert.Equal(expected, result);
        }

    }
}
