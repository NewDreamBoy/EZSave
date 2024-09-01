using EZSave.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EZSave.WPF.Utilities
{
    /// <summary>
    /// (拓展)扫描程序集中所有符合条件的 ViewModel
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services, Assembly assembly)
        {
            var viewModelTypes = typeof(ViewModelBase);
            var enumerable = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && viewModelTypes.IsAssignableFrom(t));
            foreach (var type in enumerable)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}