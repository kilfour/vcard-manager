using Moq;
using VCardManager.Core;
using VCardManager.Tests._tools;

namespace VCardManager.Tests;

public class MenuTests
{

    [Fact]
    public void Menu_Six_Exits()
    {
        var rolodex = new Mock<IAmARolodex>();
        var console = new ConsoleSpy();
        console.AddInput("6");
        new Menu(rolodex.Object, console).Run();
    }

    private Mock<IAmARolodex> PickOnceFromMenu(string choice)
    {
        var rolodex = new Mock<IAmARolodex>();
        var console = new ConsoleSpy();
        console.AddInput(choice);
        console.AddInput("6"); // <= QUIT
        new Menu(rolodex.Object, console).Run();
        return rolodex;
    }

    [Fact]
    public void Menu_One()
    {
        PickOnceFromMenu("1").Verify(a => a.ShowAllContacts(), Times.Once);
    }

    [Fact]
    public void Menu_Two()
    {
        PickOnceFromMenu("2").Verify(a => a.AddContact(), Times.Once);
    }

    [Fact]
    public void Menu_Three()
    {
        PickOnceFromMenu("3").Verify(a => a.SearchContact(), Times.Once);
    }

    [Fact]
    public void Menu_Four()
    {
        PickOnceFromMenu("4").Verify(a => a.DeleteContact(), Times.Once);
    }

    [Fact]
    public void Menu_Five()
    {
        PickOnceFromMenu("5").Verify(a => a.ExportContact(), Times.Once);
    }
}