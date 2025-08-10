using CliWrap;
using Docker.DotNet;
using Docker.DotNet.Models;
using SBEManagementSuite.Shared.Commands;
using SBEManagementSuite.Shared.Constants;
using SBEManagementSuite.Shared.Models.Docker;
using SBEManagementSuite.Shared.Services.Interfaces;
using SBEManagementSuite.Shared.Utilities;
using System.Diagnostics;
using System.Text;

namespace SBEManagementSuite.Shared.Services
{
    public class DockerService : IDockerService
    {
        private DockerClient _client;

        public DockerService()
        {
            _client = new DockerClientConfiguration().CreateClient();
        }

        public async Task<ServiceBusEmulatorContainers> GetContainerNamesAsync()
        {
            try
            {
                var containers = await _client.Containers.ListContainersAsync(new ContainersListParameters
                {
                    Filters = DockerConstants.NameFilters
                }).ConfigureAwait(false);

                var friendly = containers.MapToVM();

                //var command = "docker exec -it sqledge \"/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'gqsv(A9VDg9Q' -d SbMessageContainerDatabase00001 -Q \"SELECT name FROM EntityLookupTable\"";

                Console.WriteLine("Running command");

                var str = new StringBuilder();

                var cmd = Cli.Wrap("docker")
                        .WithArguments(args =>
                        {
                            args.Add("exec");
                            args.Add("sqledge");
                            args.Add("/opt/mssql-tools/bin/sqlcmd");
                            args.Add("-h-1");
                            args.Add("-S");
                            args.Add("localhost");
                            args.Add("-U");
                            args.Add("SA");
                            args.Add("-P");
                            args.Add("gqsv(A9VDg9Q");
                            args.Add("-d");
                            args.Add("SbMessageContainerDatabase00001");
                            args.Add("-Q");
                            args.Add("SET NOCOUNT ON; SELECT name FROM EntityLookupTable WHERE name NOT LIKE '%|%' AND name LIKE 'SBEMULATORNS:%'");
                            args.Add("-W");
                        })
                        .WithStandardOutputPipe(PipeTarget.ToStringBuilder(str));

                var response = await cmd.ExecuteAsync();

                var output = str.ToString();

                var split = output
                            .Split('\n')
                            .Where(row => !string.IsNullOrEmpty(row))
                            .Select(row => row.Split(':'))
                            .Where(rowItems => rowItems.Length == 3)
                            .Select(strings => strings[2])
                            .ToList();

                return new ServiceBusEmulatorContainers
                {
                    ServiceBusEmulator = friendly.FirstOrDefault(x => x.Name == DockerConstants.ServiceBusEmulatorContainer),
                    SqlEdge = friendly.FirstOrDefault(x => x.Name == DockerConstants.SqlEdgeDatabaseContainer)
                };
            }
            catch(Exception ex)
            {
                return new ServiceBusEmulatorContainers();
            }
        }

        public async Task StreamEventsAsync(IProgress<Message> progress)
        {
            await _client.System.MonitorEventsAsync(new ContainerEventsParameters(), progress);
        }
    }
}