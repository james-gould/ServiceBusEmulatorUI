using Avalonia.Controls;
using Avalonia.Media.Imaging;
using SBEManagementSuite.UI.Helpers;
using SBEManagementSuite.UI.ViewModels;
using System.Threading.Tasks;

namespace SBEManagementSuite.UI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = App.GetService<MainWindowViewModel>();

            InitializeComponent();
        }
    }
}