using EZSave.WPF.Utilities;
using EZSave.WPF.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
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
        private ILogger<App> appLogger;
        private IHost _host;

        protected override void OnStartup(StartupEventArgs e)
        {
            AppInit();
            ServiceProvider = _host.Services;
            appLogger = ServiceProvider.GetRequiredService<ILogger<App>>();
            appLogger.LogInformation("应用程序初始化完毕，启动!");
            var initialGuidanceWindow = ServiceProvider.GetRequiredService<InitialGuidanceWindow>();
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
                //加载配置文件
                config.AddJsonFile($"Configurations/appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json", optional: true, reloadOnChange: true);
            }).ConfigureServices((context, services) =>
            {
                //注入服务
                services.AddViewModels(Assembly.GetExecutingAssembly());
                services.AddTransient<InitialGuidanceWindow>();
            }).ConfigureLogging((context, logging) =>
            {
                // 清除其他日志提供程序
                logging.ClearProviders();
                //配置 Serilog 使用配置文件
                Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(context.Configuration)
                    .CreateLogger();
                //使用 Serilog 作为日志提供程序
                logging.AddSerilog();
            }).Build();
        }
    }
}