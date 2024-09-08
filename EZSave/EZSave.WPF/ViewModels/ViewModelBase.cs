using CommunityToolkit.Mvvm.ComponentModel;

namespace EZSave.WPF.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        public abstract void ViewWindowInit();
    }
}