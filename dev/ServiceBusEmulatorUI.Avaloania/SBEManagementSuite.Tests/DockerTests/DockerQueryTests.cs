using SBEManagementSuite.Shared.Constants;
using SBEManagementSuite.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Tests.DockerTests
{
    [Collection("DockerQueryCollection")]
    public class DockerQueryTests
    {
        private DockerService _docker;
        public DockerQueryTests()
        {
            _docker = new DockerService();
        }

        [Fact]
        public async Task ListContainersTestAsync()
        {
            var result = await _docker.GetContainerNamesAsync();

            Assert.NotNull(result);

            Assert.Equal(DockerConstants.SqlEdgeDatabaseContainer, result.SqlEdge!.Name);
            Assert.Equal(DockerConstants.ServiceBusEmulatorContainer, result.ServiceBusEmulator!.Name);
        }
    }
}
