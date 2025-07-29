
using Microsoft.AspNetCore.Builder;


namespace Ambev.DeveloperEvaluation.IoC;

public static class ModuleInitializerExtensions
{
    public static void RegisterModuleInitializers(this WebApplicationBuilder builder)
    {
        var initializers = typeof(IModuleInitializer).Assembly
            .GetTypes()
            .Where(t => typeof(IModuleInitializer).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IModuleInitializer>();

        foreach (var initializer in initializers)
        {
            initializer.Initialize(builder);
        }
    }
}