using VCardManager.CLI;
using VCardManager.Core;

var console = new SystemConsole();
var fileStore = new FileSystemStore();

var receptionist = new TheReceptionist();
var inquisitor = new Inquisitor(console, receptionist);
var printer = new ThePrinter(console);
var stackOfPaper = new StackOfPaper(fileStore);
var rolodex = new Rolodex(stackOfPaper, inquisitor, printer);

new Menu(rolodex, console).Run();





