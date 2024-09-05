using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace EZSave.WPF.ViewModels
{
    public partial class InitialGuidanceWindowViewModel : ViewModelBase
    {

        private readonly ILogger<InitialGuidanceWindowViewModel> _logger;

        public InitialGuidanceWindowViewModel(ILogger<InitialGuidanceWindowViewModel> logger)
        {
            this._logger = logger;
            _logger.LogTrace("LogDebug 应该不输出把");
            _logger.LogWarning("InitialGuidanceWindowViewModel 报警");
        }

        [ObservableProperty]
        private string _title = "引导窗口";

        [RelayCommand]
        private void AddPlan()
        {
            Title = "添加计划";
        }

    }
}