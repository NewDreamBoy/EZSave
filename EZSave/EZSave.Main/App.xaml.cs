using EZSave.Main.Core.Services.Implementations;
using EZSave.Main.Core.Services.Interfaces;
using EZSave.Main.Infrastructure.AutoVMBinding;
using EZSave.Main.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using System.Reflection;
using System.Windows;

namespace EZSave.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider AppServiceProvider { get; private set; }
        private ILogger<App> appLogger;
        private IHost _host;

        protected override void OnStartup(StartupEventArgs e)
        {
            ApplicationInit();
        }

        /// <summary>
        /// 应用程序初始化
        /// </summary>
        public void ApplicationInit()
        {
            _host = Host.CreateDefaultBuilder().ConfigureAppConfiguration((context, config) =>
            {
                // 获取当前工作目录
                var basePath = Directory.GetCurrentDirectory();
                //设置配置文件目录
                config.SetBasePath(basePath);
                //加载配置文件
                config.AddJsonFile(Path.Combine(basePath, "Configurations", $"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json"), optional: true, reloadOnChange: true);
            }).ConfigureServices((context, services) =>
            {
                //VM自动绑定
                services.AddAutoVmBinding(Assembly.GetExecutingAssembly());
                services.AddSingleton<MainWindow>();
                services.AddTransient<WelcomeView>();
                services.AddTransient<HomeView>();
                services.AddTransient<IGetImageService, GetImageService>();
                services.AddTransient<INavigationService, NavigationService>();
            }).ConfigureLogging((context, logging) =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(context.Configuration)
                    .CreateLogger();
                logging.AddSerilog();
            }).
            Build();

            AppServiceProvider = _host.Services;
            appLogger = AppServiceProvider.GetRequiredService<ILogger<App>>();

            //初始化主界面
            var mainWindow = AppServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            appLogger.LogInformation("应用程序初始化完毕");
        }
    }
}