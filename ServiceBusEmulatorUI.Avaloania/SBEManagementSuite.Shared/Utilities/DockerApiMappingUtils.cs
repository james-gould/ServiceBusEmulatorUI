using Docker.DotNet.Models;
using SBEManagementSuite.Shared.Models.Docker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Utilities
{
    public static class DockerApiMappingUtils
    {
        /// <summary>
        /// Maps the verbose DockerAPI.ListContainersAsync response to a friendlier model
        /// </summary>
        /// <param name="response">The response from the DockerAPI client</param>
        /// <returns>A mapped list a container names</returns>
        public static IEnumerable<DockerContainerFriendlyVM> MapToVM(this IList<ContainerListResponse> response)
        {
            var result = new List<DockerContainerFriendlyVM>();

            if (response == null || response.Count == 0)
                yield return new DockerContainerFriendlyVM();

            foreach (var item in response!)
            {
                yield return new DockerContainerFriendlyVM
                {
                    ContainerId = item.ID,
                    Image = item.Image,
                    Command = item.Command,
                    Created = item.Created,
                    Online = item.Status.Contains("Up"),
                    Ports = string.Join(",", item.Ports.Select(x => $"{x.IP}:{x.PublicPort}")),
                    Name = FormatContainerNames(item.Names)
                };
            }
        }

        /// <summary>
        /// Format container names, removing prepended slash if it's there
        /// </summary>
        /// <param name="containerNames"></param>
        /// <returns></returns>
        private static string FormatContainerNames(IList<string> containerNames)
        {
            var correctedNames = new List<string>();

            foreach (var name in containerNames)
            {
                var correctedName = name;

                var hasSlash = name.IndexOf('/');

                if (hasSlash != -1)
                    correctedName = correctedName[1..];

                correctedNames.Add(correctedName);
            }

            return string.Join(",", correctedNames);
        }
    }
}
