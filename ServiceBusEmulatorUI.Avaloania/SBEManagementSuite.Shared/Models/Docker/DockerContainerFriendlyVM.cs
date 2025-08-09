using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Models.Docker
{
    public class DockerContainerFriendlyVM
    {
        public DockerContainerFriendlyVM(bool online = false)
        {
            Online = online;
        }

        public string? ContainerId { get; set; }
        public string? Image { get; set; }
        public string? Command { get; set; }
        public DateTime? Created { get; set; }
        public bool Online { get; set; }
        public string? Ports { get; set; }
        public string? Name { get; set; }
    }

    public class ServiceBusEmulatorContainers
    {
        public ServiceBusEmulatorContainers()
        {
            ServiceBusEmulator = new DockerContainerFriendlyVM();
            SqlEdge = new DockerContainerFriendlyVM();
        }

        public DockerContainerFriendlyVM? ServiceBusEmulator { get; set; }
        public DockerContainerFriendlyVM? SqlEdge { get; set; }
    }
}
