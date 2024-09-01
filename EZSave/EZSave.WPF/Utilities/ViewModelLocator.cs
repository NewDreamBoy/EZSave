using Microsoft.Extensions.DependencyInjection;

namespace EZSave.WPF.Utilities
{
    public class ViewModelLocator
    {
        public static TViewModel ResolveViewModel<TViewModel>() where TViewModel : class
        {
            return App.ServiceProvider.GetRequiredService<TViewModel>();
        }
    }
}