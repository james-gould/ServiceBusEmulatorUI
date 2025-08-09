using Docker.DotNet.Models;
using SBEManagementSuite.Shared.Models.Docker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Services.Interfaces
{
    public interface IDockerService : IBaseService
    {
        Task<ServiceBusEmulatorContainers> GetContainerNamesAsync();
        Task StreamEventsAsync(IProgress<Message> progress);
    }
}
