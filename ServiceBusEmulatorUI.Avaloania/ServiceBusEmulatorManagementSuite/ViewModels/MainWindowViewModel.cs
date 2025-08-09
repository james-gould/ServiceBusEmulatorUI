using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SBEManagementSuite.Shared.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SBEManagementSuite.UI.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private DockerContainersStatusViewModel _containersPollViewModel;

        public MainWindowViewModel(DockerContainersStatusViewModel containersViewModel)
        {
            _containersPollViewModel = containersViewModel;
        }

        [ObservableProperty]
        private string? _helloWorld = "Hello, world again!";

    }
}
