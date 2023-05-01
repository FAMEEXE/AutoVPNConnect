using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Ibf.Wpf.AutoConnector.Service;
using Ibf.Wpf.AutoConnector.View;
using Ibf.Wpf.AutoConnector.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Ibf.Wpf.AutoConnector
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
            Startup += AppStartup;
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<MainWindow>();
            serviceCollection.AddScoped<MainViewModel>();
            serviceCollection.AddScoped<IRegistryService, RegistryService>();
            serviceCollection.AddSingleton<IRegistrySettingService, RegistrySettingService>();
        }

        private async void AppStartup(object sender, StartupEventArgs e)
        {
            try
            {
                var registrySettingService = serviceProvider.GetRequiredService<IRegistrySettingService>();
                await registrySettingService.Load();
                
                var window = serviceProvider.GetRequiredService<MainWindow>();
                window.Show();
            }
            catch (Exception exception)
            {
                // skip
            }
        }
    }
}