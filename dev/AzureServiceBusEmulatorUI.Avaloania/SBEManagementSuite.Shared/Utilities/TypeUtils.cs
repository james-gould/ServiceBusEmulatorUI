using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Utilities
{
    public static class TypeUtils
    {
        /// <summary>
        /// Creates an instance of the given type
        /// </summary>
        /// <typeparam name="TType">The type to create a new instance of</typeparam>
        /// <returns>The newly created instance or null</returns>
        public static TType CreateInstance<TType>() where TType : class
        {
            return (TType)Activator.CreateInstance(typeof(TType))!;
        }
    }
}
