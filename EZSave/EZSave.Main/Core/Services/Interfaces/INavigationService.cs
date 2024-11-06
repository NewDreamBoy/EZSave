using System.Windows;

namespace EZSave.Main.Core.Services.Interfaces
{
    public interface INavigationService
    {
        bool NavigateTo<TView>() where TView : FrameworkElement;
    }
}