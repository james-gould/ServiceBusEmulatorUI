using Avalonia.Data;
using Avalonia.Threading;
using CliWrap;
using CliWrap.Buffered;
using CommunityToolkit.Mvvm.ComponentModel;
using Docker.DotNet.Models;
using SBEManagementSuite.Shared.Constants;
using SBEManagementSuite.Shared.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.UI.ViewModels
{
    public partial class DockerContainersStatusViewModel : ViewModelBase
    {
        private IDockerService _dockerService;
        private Progress<Message> _dockerProgress;

        public DockerContainersStatusViewModel(IDockerService docker)
        {
            _dockerService = docker;

            _dockerProgress = new Progress<Message>(CaptureDockerProgress);

            Task.Run(async () => await _dockerService.StreamEventsAsync(_dockerProgress));

            Task.Run(UpdateDockerContainersAsync);
        }

        [ObservableProperty]
        private bool _serviceBusRunning = false;

        [ObservableProperty]
        private bool _sqlEdgeRunning = false;

        [ObservableProperty]
        private bool _shouldCancelPolling = false;

        [ObservableProperty]
        private string _types = string.Empty;

        [ObservableProperty]
        private string _containerNames = string.Empty;

        [ObservableProperty]
        private string _containerAction = string.Empty;

        private void CaptureDockerProgress(Message message)
        {
            if (message is null)
                return;

            if (!DockerConstants.AcceptableEventMessageTypes.Contains(message.Type))
                return;

            Types += (message.Type ?? string.Empty) + Environment.NewLine;

            if (message.Actor is null)
                return;

            var name = message.Actor.Attributes.TryGetValue("name", out var value) ? value : "No Name Found";

            ContainerNames += name + Environment.NewLine;

            ContainerAction += message.Action += Environment.NewLine;

            if (name is DockerConstants.SqlEdgeDatabaseContainer)
                SqlEdgeRunning = message.IsContainerAlive();

            else if (name is DockerConstants.ServiceBusEmulatorContainer)
                ServiceBusRunning = message.IsContainerAlive();
        }

        private async Task UpdateDockerContainersAsync()
        {
            var containers = await _dockerService.GetContainerNamesAsync();

            ServiceBusRunning = containers?.ServiceBusEmulator?.Online ?? false;
            SqlEdgeRunning = containers?.SqlEdge?.Online ?? false;
        }
    }
}
