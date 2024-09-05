using EZSave.WPF.Utilities;
using EZSave.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace EZSave.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        private IHost _host;

        protected override void OnStartup(StartupEventArgs e)
        {
            AppInit();
            ServiceProvider = _host.Services;
            var initialGuidanceWindow = _host.Services.GetRequiredService<InitialGuidanceWindow>();
            initialGuidanceWindow.Show();
            base.OnStartup(e);
        }

        private void AppInit()
        {
            _host = Host.CreateDefaultBuilder().ConfigureAppConfiguration((context, config) =>
            {
                //获取应用程序根目录
                var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\.."));
                //设置配置文件目录
                config.SetBasePath(basePath);
                //获取当前运行环境
                var env = context.HostingEnvironment;
                //加载配置文件
                config.AddJsonFile($"Configurations/appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json", optional: true, reloadOnChange: true);

            }).ConfigureServices((context, services) =>
            {
                //注入服务
                services.AddViewModels(Assembly.GetExecutingAssembly());
                services.AddTransient<InitialGuidanceWindow>();

            }).ConfigureLogging((context, logging) =>
            {
                // 从配置文件加载日志配置
                logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                if (Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") == "Development")
                {
                    logging.AddConsole(); // 在开发环境中输出到控制台
                }
                else
                {
                    
                }
            }).Build();
        }
    }
}