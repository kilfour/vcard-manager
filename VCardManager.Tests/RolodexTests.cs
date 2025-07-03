using Moq;
using VCardManager.Core;

namespace VCardManager.Tests;

public class RolodexTests
{
    private readonly Mock<IAmAStackOfPaper> stackOfPaper;
    private readonly Mock<IAmInquisitive> inquisitor;
    private readonly Mock<IAmAPrinter> printer;
    private readonly IAmARolodex rolodex;

    public RolodexTests()
    {
        stackOfPaper = new Mock<IAmAStackOfPaper>();
        inquisitor = new Mock<IAmInquisitive>();
        printer = new Mock<IAmAPrinter>();
        rolodex = new Rolodex(stackOfPaper.Object, inquisitor.Object, printer.Object);
    }

    [Fact]
    public void ShowAllContacts()
    {
        var contact = new ContactCard("the test contact", "", "", "");
        stackOfPaper.Setup(a => a.GetAllContactCards()).Returns([contact]);
        rolodex.ShowAllContacts();
        stackOfPaper.Verify(a => a.GetAllContactCards(), Times.Once);
        printer.Verify(a => a.PrintContactCards(
            It.Is<IEnumerable<ContactCard>>(b => b.First().FirstName == "the test contact")), Times.Once);
    }

    [Fact]
    public void AddContact()
    {
        var contact = new ContactCard("the test contact", "m", "33", "@");
        inquisitor.Setup(a => a.GetContactInformation()).Returns(contact);
        rolodex.AddContact();
        stackOfPaper.Verify(a => a.Add(contact), Times.Once);
    }

    [Fact]
    public void SearchContact()
    {
        var contact = new ContactCard("the test contact", "m", "33", "@");
        inquisitor.Setup(a => a.GetSearchString()).Returns("33");
        stackOfPaper.Setup(a => a.FindAllContactCards("33")).Returns([contact]);

        rolodex.SearchContact();

        inquisitor.Verify(a => a.GetSearchString(), Times.Once);
        stackOfPaper.Verify(a => a.FindAllContactCards("33"), Times.Once);
        printer.Verify(a => a.PrintContactCards(
            It.Is<IEnumerable<ContactCard>>(b => b.First().FirstName == "the test contact")), Times.Once);
    }

    [Fact]
    public void DeleteContact_Confirmed()
    {
        var contact = new ContactCard("the test contact", "m", "33", "@");
        inquisitor.Setup(a => a.GetSearchString()).Returns("33");
        inquisitor.Setup(a => a.Confirm()).Returns(true); // <= CONFIRMED
        stackOfPaper.Setup(a => a.FindAllContactCards("33")).Returns([contact]);

        rolodex.DeleteContact();

        inquisitor.Verify(a => a.GetSearchString(), Times.Once);
        stackOfPaper.Verify(a => a.FindAllContactCards("33"), Times.Once);
        printer.Verify(a => a.PrintConfirmDeletion(), Times.Once);
        printer.Verify(a => a.PrintContactCards(
            It.Is<IEnumerable<ContactCard>>(b => b.First().FirstName == "the test contact")));
        inquisitor.Verify(a => a.Confirm(), Times.Once);
        stackOfPaper.Verify(a => a.DeleteAllThese("33"), Times.Once);
        printer.Verify(a => a.PrintCardsDeleted(), Times.Once);
    }
}