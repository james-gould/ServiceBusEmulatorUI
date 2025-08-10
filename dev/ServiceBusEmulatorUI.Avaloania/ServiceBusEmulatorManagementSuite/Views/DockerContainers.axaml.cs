using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SBEManagementSuite.UI.ViewModels;

namespace SBEManagementSuite.UI.Views;

public partial class DockerContainers : UserControl
{
    public DockerContainers()
    {
        DataContext = App.GetService<DockerContainersStatusViewModel>();

        InitializeComponent();
    }
}