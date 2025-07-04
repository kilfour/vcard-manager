using Microsoft.Extensions.DependencyInjection;
using VCardManager.CLI;
using VCardManager.Core;
using VCardManager.Core.Abstractions;

var services = new ServiceCollection();
services.AddTransient<IConsole, SystemConsole>();
services.AddTransient<IFileStore, FileSystemStore>();
services.AddTransient<TheReceptionist>();
services.AddTransient<IAmInquisitive, Inquisitor>();
services.AddTransient<IAmAPrinter, ThePrinter>();
services.AddTransient<IAmAStackOfPaper, StackOfPaper>();
services.AddTransient<IAmARolodex, Rolodex>();
services.AddTransient<IMenu, Menu>();

services.BuildServiceProvider()
    .GetRequiredService<IMenu>()
    .Run();





