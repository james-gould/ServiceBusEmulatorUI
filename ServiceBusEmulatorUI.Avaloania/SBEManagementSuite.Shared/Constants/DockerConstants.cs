using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SBEManagementSuite.Shared.Constants
{
    public static class DockerConstants
    {
        public const string ServiceBusEmulatorContainer = "servicebus-emulator";
        public const string SqlEdgeDatabaseContainer = "sqledge";

        public const string EventContainerType = "container";

        private const string _dockerStartEvent = "start";
        private const string _dockerStopEvent = "stop";

        public static readonly string[] AcceptableEventMessageTypes = [ "container" ];

        // Good lord Docker.DotNet why
        public static IDictionary<string, IDictionary<string, bool>> NameFilters = new Dictionary<string, IDictionary<string, bool>>()
        {
            {
                "name",
                new Dictionary<string, bool>()
                {
                    { ServiceBusEmulatorContainer, true },
                    { SqlEdgeDatabaseContainer, true }
                }
            }
        };

        public static bool IsContainerAlive(this Message message)
        {
            // remove /r/n from the message
            var action = message.Action.Trim();
            
            return action == _dockerStartEvent;
        }
    }
}
