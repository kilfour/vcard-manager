using VCardManager.Core.Abstractions;

namespace VCardManager.Core;

public interface IAmARolodex
{
    void ShowAllContacts();
    void AddContact();
    void SearchContact();
    void DeleteContact();
    void ExportContact();
}

public class Rolodex : IAmARolodex
{
    private readonly IAmAStackOfPaper stackOfPaper;
    private readonly IAmInquisitive inquisitor;
    private readonly IAmAPrinter printer;
    private readonly IFileStore fileStore;

    public Rolodex(IAmAStackOfPaper stackOfPaper, IAmInquisitive inquisitor, IAmAPrinter printer, IFileStore fileStore)
    {
        this.stackOfPaper = stackOfPaper;
        this.inquisitor = inquisitor;
        this.printer = printer;
        this.fileStore = fileStore;
    }

    public void ShowAllContacts()
    {
        printer.PrintContactCards(stackOfPaper.GetAllContactCards());
    }

    public void AddContact()
    {
        stackOfPaper.Add(inquisitor.GetContactInformation());
    }

    public void SearchContact()
    {
        printer.PrintContactCards(stackOfPaper.FindAllContactCards(inquisitor.GetSearchString()));
    }

    public void DeleteContact()
    {
        var searchString = inquisitor.GetSearchString();
        var cards = stackOfPaper.FindAllContactCards(searchString);
        printer.PrintConfirmDeletion();
        printer.PrintContactCards(cards);
        if (inquisitor.Confirm())
        {
            stackOfPaper.DeleteAllThese(searchString);
            printer.PrintCardsDeleted();
        }
    }

    public void ExportContact()
    {
        var searchString = inquisitor.GetSearchString();
        var cards = stackOfPaper.FindAllContactCards(searchString);
        printer.PrintConfirmExport();
        printer.PrintContactCards(cards);
        if (inquisitor.Confirm())
        {
            foreach (var card in cards)
            {
                fileStore.WriteAllText($"{card.FullName.Replace(" ", "_")}.vcf", card.ToVCardFormatString());
            }
        }
    }
}
