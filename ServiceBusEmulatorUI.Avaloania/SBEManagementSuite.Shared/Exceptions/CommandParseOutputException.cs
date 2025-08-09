using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Exceptions
{
    public class CommandParseOutputException : Exception
    {
        public CommandParseOutputException(string command) :
            base($"Failed to parse StdOutput from command {command}") { }
    }
}
