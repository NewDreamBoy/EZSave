using EZSave.Main.Core.Services.Interfaces;
using EZSave.Main.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Microsoft.Extensions.Logging;

namespace EZSave.Main.Core.Services.Implementations
{
    public class NavigationService : INavigationService
    {
        private readonly ILogger<NavigationService> _logger;

        public NavigationService(ILogger<NavigationService> logger)
        {
            _logger = logger;
        }

        public bool NavigateTo<TView>() where TView : FrameworkElement
        {
            try
            {
                var view = App.AppServiceProvider.GetService<TView>();
                if (view != null)
                {
                    var mainWindow = App.Current.MainWindow as MainWindow;
                    if (mainWindow?.MainContent != null)
                    {
                        mainWindow.MainContent.Content = view;
                        return true;
                    }
                }
                _logger.LogWarning($"导航到 {view} 异常");
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }   
    }
}