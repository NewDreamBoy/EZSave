using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EZSave.WPF.ViewModels
{
    public partial class InitialGuidanceWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _title = "引导窗口";

        [RelayCommand]
        private void AddPlan()
        {
            Title = "添加计划";
        }

    }
}