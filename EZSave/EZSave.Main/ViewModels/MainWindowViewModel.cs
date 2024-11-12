using CommunityToolkit.Mvvm.Input;
using EZSave.Main.Core.Services.Interfaces;
using EZSave.Main.Infrastructure.AutoVMBinding;
using EZSave.Main.Views;
using Microsoft.Extensions.Logging;
using System.IO;

namespace EZSave.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly ILogger<MainWindowViewModel> _logger;
        private readonly INavigationService _navigationService;

        public MainWindowViewModel(ILogger<MainWindowViewModel> logger, INavigationService navigationService)
        {
            _logger = logger;
            _navigationService = navigationService;
        }

        /// <summary>
        /// 处理用户第一次登录的逻辑
        /// </summary>
        [RelayCommand]
        public void HandleFirstLogin()
        {
            VmInitialize();
        }

        public override void ViewWindowInit()
        {
            //判断是否是新老用户
            var filePath = Directory.GetCurrentDirectory() + @"\Data";
            if (Directory.Exists(filePath))
            {
                _logger.LogInformation("旧用户");
                _navigationService.NavigateTo<HomeView>();
            }
            else
            {
                _logger.LogInformation("新用户");
                _navigationService.NavigateTo<WelcomeView>();
                //Directory.CreateDirectory(filePath);
            }
        }
    }
}