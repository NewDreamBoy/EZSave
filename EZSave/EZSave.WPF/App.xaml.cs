using EZSave.WPF.Utilities;
using EZSave.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Windows;

namespace EZSave.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
            var initialGuidanceWindow = ServiceProvider.GetRequiredService<InitialGuidanceWindow>();
            initialGuidanceWindow.Show();

            base.OnStartup(e);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddViewModels(Assembly.GetExecutingAssembly());
            services.AddTransient<InitialGuidanceWindow>();
        }
    }
}