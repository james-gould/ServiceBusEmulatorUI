using SBEManagementSuite.Shared.Commands.Models;
using SBEManagementSuite.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Commands
{
    public static class CommandResultMapper
    {
        /// <summary>
        /// Maps the StdOut to <see cref="IEnumerable{TRepresentation}"/>, derived from <see cref="StdOutBase{TRepresentation}"/>
        /// </summary>
        /// <typeparam name="TRepresentation">The type to map to</typeparam>
        /// <param name="stdOut">The StdOut from an executed command</param>
        /// <returns></returns>
        public static IEnumerable<TRepresentation> MapToRepresentation<TRepresentation>(string[] stdOut) where TRepresentation : StdOutBase<TRepresentation>
        {
            var instance = TypeUtils.CreateInstance<TRepresentation>();

            // No output or every line is an empty string
            if (stdOut.Count() == 0 || stdOut.All(string.IsNullOrEmpty))
                return new List<TRepresentation>() { instance };

            return instance.MapOutput(stdOut);
        }
    }
}
