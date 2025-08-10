using CommunityToolkit.Mvvm.ComponentModel;
using SBEManagementSuite.Shared.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.UI.ViewModels
{
    public class ViewModelBase : ObservableObject, IBaseViewModel
    {
        public delegate Task AsyncEventHandle(object sender, EventArgs e);
    }
}
