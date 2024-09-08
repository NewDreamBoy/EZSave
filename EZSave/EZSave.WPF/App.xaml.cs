using EZSave.WPF.Services;
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
            try
            {
                AppInit();
                ServiceProvider = _host.Services;
                appLogger = ServiceProvider.GetRequiredService<ILogger<App>>();
                appLogger.LogInformation("应用程序初始化完毕，启动!");
                if (CheckIfNewUser())
                {
                    var initialGuidanceWindow = ServiceProvider.GetRequiredService<InitialGuidanceWindow>();
                    initialGuidanceWindow.Show();
                }
                else
                {
                    var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
                    mainWindow.Show();
                }
                base.OnStartup(e);
            }
            catch (Exception ex)
            {
                appLogger.LogError(ex, "应用程序启动失败");
                throw;
            }
        }

        private void AppInit()
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
                #region View ViewModel注入

                //自动注入继承自 ViewModelBase 的 ViewModel
                services.AddViewModels(Assembly.GetExecutingAssembly());
                services.AddTransient<InitialGuidanceWindow>();
                services.AddTransient<MainWindow>();

                #endregion

                #region 其他服务

                services.AddTransient<IImageService, ImageService>();

                #endregion

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

        public bool CheckIfNewUser()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\Data";
            if (Directory.Exists(filePath))
            {
                appLogger.LogInformation("旧用户");
                return false;
            }
            else
            {
                Directory.CreateDirectory(filePath);
                appLogger.LogInformation("新用户");
                return true;
            }
        }
    }
}