using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Hosting;
using SBEManagementSuite.Shared.Services;
using SBEManagementSuite.Shared.Services.Interfaces;
using SBEManagementSuite.UI.Helpers;
using SBEManagementSuite.UI.ViewModels;
using SBEManagementSuite.UI.Views;
using System;

namespace SBEManagementSuite
{
    public partial class App : Application
    {
        public IHost AppHost { get; }

        public App()
        {
            AppHost =
                Host.CreateDefaultBuilder()
                .UseContentRoot(AppContext.BaseDirectory)
                .ConfigureServices((context, services) =>
                {
                    services.AddCustomServices();
                    services.AddViewModels();
                })
                .Build();

            AppHost.Start();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // Remove Avalonia data validation, use Community Toolkit instead
            BindingPlugins.DataValidators.RemoveAt(0);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }

        public static TService GetService<TService>() where TService : IBaseViewModel
        {
            if ((App.Current as App)!.AppHost.Services.GetService(typeof(TService)) is not TService service)
                throw new ArgumentException($"{typeof(TService)} needs to be registered");

            return service;
        }
    }
}