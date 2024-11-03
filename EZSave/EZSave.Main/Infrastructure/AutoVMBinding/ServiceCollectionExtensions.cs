using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EZSave.Main.Infrastructure.AutoVMBinding
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoVmBinding(this IServiceCollection services, Assembly assembly)
        {
            var viewModelTypes = typeof(ViewModelBase);
            //匹配符合条件的VM
            var enumerable = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && viewModelTypes.IsAssignableFrom(t));
            foreach (var type in enumerable)
            {
                services.AddTransient(type);
            }
            return services;
        }
    }
}