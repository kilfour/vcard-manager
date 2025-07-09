
using VCardManager.Tests._tools;

namespace VCardManager.Tests.IntegrationTests;

public class FirstIntegrationTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public void AddingAContactCard()
    {
        Directory.Delete("data", true);
        Directory.CreateDirectory("data");
        using (File.Create("./data/contacts.vcf")) { }
        var consoleSpy = new ConsoleSpy();
        consoleSpy.AddInput("Mark", "Meyers", "0487112233", "mail");
        var rolodex = Get.TheApp(consoleSpy);
        rolodex.AddContact();
        var text = File.ReadAllText("./data/contacts.vcf");
        Assert.Equal(
@"BEGIN:VCARD
FN:Mark Meyers
TEL:0487112233
EMAIL:mail
END:VCARD", text);

    }
}