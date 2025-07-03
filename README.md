# 📇 VCard Manager

### Hoofddoel van de opdracht

Bouw een eenvoudige console-applicatie die een menu toont met volgende opties:

* Alle contacten tonen
  - 1 contact per lijn, 1 lijn per contact in volgend formaat : `Mark Meyers: kilfour@gmail.com, 0487.11.22.33` 
* Een nieuw contact toevoegen
  - Telefoonnummer valideren, geldig :
    - 0487112233
    - 487112233
    - 0487/11.22.33
    - 487/11.22.33
    - 0487.11.22.33
    - 487.11.22.33
* Zoeken naar een contact op naam
* Een contact verwijderen
* Een contact exporteren naar een apart `.vcf` bestand
* Een optie om het programma te beïndigen.

Implementeer de aangeboden functionaliteit.

Alle contacten worden opgeslagen in **één enkel bestand**: `contacts.vcf` volgens het vCard-formaat:

```
BEGIN:VCARD
FN:Voornaam Achternaam
TEL:+32 Telefoonnummer
EMAIL:email@example.com
END:VCARD
```

### Setup

Volg de stappen in [dit bestand](./setup.md) om je project aan te maken met de juiste structuur.
Hierna kan je het console project opstarten via de terminal met : `dotnet run --project .\VCardManager.CLI\VCardManager.CLI.csproj`.

### Design Requirements

Volg de guidelines in [dit bestand](./design.md) om een *clean* resultaat op te leveren.

### Maak een plan !

### Extra Informatie
 - [Interfaces](../4.CSharp101/8.Classes/interfaces.md)
 - Dependency Injection
   - [Een voorbeeld](../4.CSharp101/8.Classes/composition-vs-inheritence.md), in de paragraaf **C# Best Practice**
   - [Simpele DI in .Net](./basic-di.md)
 - [File Handling](./file-handling.md)

### [Vragen Lijst](./questionaire.md)

Deze vragenlijst is bedoeld om na te gaan of je de concepten uit de VCard Manager-oefening goed begrijpt. Beantwoord de vragen kort maar duidelijk. Gebruik eventueel voorbeelden uit je eigen code.






