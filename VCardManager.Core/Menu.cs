using VCardManager.Core.Abstractions;

namespace VCardManager.Core;

public interface IMenu
{
    void Run();
}

public class Menu : IMenu
{
    private readonly IAmARolodex rolodex;
    private readonly IConsole console;

    public Menu(IAmARolodex rolodex, IConsole console)
    {
        this.rolodex = rolodex;
        this.console = console;
    }

    public void Run()
    {
        var running = true;
        while (running)
        {
            ShowMenu();
            running = HandleChoice(console.ReadLine());
        }
    }

    private void ShowMenu()
    {
        console.WriteLine("1. Show Contacts");
        console.WriteLine("2. Add Contact");
        console.WriteLine("3. Search Contact");
        console.WriteLine("4. Delete Contact");
        console.WriteLine("5. Export Contact");
        console.WriteLine("6. Exit");
        console.Write("Choose an option: ");
    }

    private bool HandleChoice(string choice)
    {
        switch (choice)
        {
            case "1": rolodex.ShowAllContacts(); break;
            case "2": rolodex.AddContact(); break;
            case "3": rolodex.SearchContact(); break;
            case "4": rolodex.DeleteContact(); break;
            case "5": rolodex.ExportContact(); break;
            case "6": return false;
            default: console.WriteLine("Invalid choice."); break;
        }
        return true;
    }
}
