using Microsoft.Extensions.DependencyInjection;
using VCardManager.Core;
using VCardManager.Core.Abstractions;

namespace VCardManager.Tests.IntegrationTests;

public static class Get
{
    public static IAmARolodex TheApp(IConsole consoleSpy)
    {
        var services = new ServiceCollection();
        services.AddSingleton(p => consoleSpy);
        services.AddTransient<IFileStore, FileSystemStore>();
        services.AddTransient<TheReceptionist>();
        services.AddTransient<IAmInquisitive, Inquisitor>();
        services.AddTransient<IAmAPrinter, ThePrinter>();
        services.AddTransient<IAmAStackOfPaper, StackOfPaper>();
        services.AddTransient<IAmARolodex, Rolodex>();
        return services.BuildServiceProvider().GetRequiredService<IAmARolodex>();
    }
}
