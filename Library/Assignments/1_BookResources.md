# Övning: Library Booking System

Du ska skapa ett system för ett bibliotek där människor kan boka resurser (t.ex. böcker, datorer eller grupprum). Systemet ska demonstrera arv, interfaces och inkapsling.

## Kravspecifikation

### Resurser (Arv)
- Alla resurser i biblioteket (t.ex. böcker, datorer och grupprum) ska ha gemensamma egenskaper, såsom `ID`, `Name` och `IsAvailable`.
- Skapa en basklass `Resource` och låt specifika resurser (t.ex. `Book`, `Computer`, `StudyRoom`) ärva från den.

### Bokningsfunktionalitet (Interface)
- Alla resurser som kan bokas ska implementera ett interface `IBookable`.
- Detta interface ska kräva följande metoder:
  - `Book(string user)` – bokar resursen för en användare.
  - `CancelBooking()` – avbokar resursen.

### Inkapsling
- Varje resurs ska ha en privat egenskap `IsAvailable` som spårar tillgänglighet.
- Implementera en privat metod `CheckAvailability()` som kontrollerar om resursen kan bokas.
- Metoderna `Book()` och `CancelBooking()` ska vara publika men använda `CheckAvailability()` för att säkerställa korrekt logik.

### Systemfunktionalitet
- Skapa en klass `LibrarySystem` för att hantera en lista av resurser.
- Lägg till metoder för att:
  - Visa alla resurser och deras status (bokad/ledig).
  - Tillåta användare att boka eller avboka resurser.
  - Söka efter resurser baserat på `ID` eller `Name`.

## Steg att Implementera

1. **Skapa basklassen Resource:**
   - Egenskaper:
     - `ID` (string)
     - `Name` (string)
     - `IsAvailable` (privat).
   - En metod `CheckAvailability()` som returnerar om resursen är ledig.

2. **Skapa subklasserna Book, Computer och StudyRoom:**
   - Dessa klasser ska ärva från `Resource`.

3. **Skapa interfacet IBookable:**
   - Definiera metoderna `Book(string user)` och `CancelBooking()`.

4. **Implementera interfacet i klasser som ska kunna bokas (t.ex. Book och Computer).**

5. **Implementera inkapsling:**
   - Gör `IsAvailable` privat i `Resource`.
   - Använd `CheckAvailability()` i metoden `Book()` för att kontrollera om bokning är möjlig.
   - Se till att `CancelBooking()` förhindrar avbokning om resursen inte är bokad.

6. **Skapa klassen LibrarySystem:**
   - Hantera en lista av resurser (`List<Resource>`).
   - Lägg till metoder för att:
     - Visa resurser och deras status.
     - Tillåta bokning och avbokning.
     - Söka efter resurser via `ID` eller `Name`.

## Diskussionsfrågor

- Varför är det bra att använda ett interface för bokning istället för att lägga metoderna direkt i basklassen?
- Hur hjälper inkapsling till att skydda data och förhindra fel i detta scenario?
- Hur skulle du vidareutveckla systemet för att hantera fler typer av resurser eller funktioner?

## Extrauppgifter

### Utöka systemet med en ny typ av resurs
- Lägg till en ny resurstyp, t.ex. en `Magazine`, som också kan bokas. Hur skiljer sig denna typ från en `Book`? Behöver du justera något i koden för att hantera detta?

### Lägg till en tidsbegränsning
- Uppdatera interfacet `IBookable` så att bokningar endast gäller en viss tid, t.ex. 2 timmar för datorer. Hur påverkar detta implementeringen?

### Hantera icke-bokningsbara resurser
- Lägg till en ny typ av resurs, t.ex. en `Exhibit`, som inte kan bokas. Hur kan du säkerställa att endast bokningsbara resurser implementerar `IBookable` utan att förändra basklassen?

### Lägg till ett loggningssystem
- Implementera en funktion i `LibrarySystem` som loggar varje gång en resurs bokas eller avbokas. Hur kan du använda enkapsling för att skydda loggfilerna?

### Skapa ett användargränssnitt
- Implementera ett enklare textbaserat gränssnitt där användaren kan lista resurser, boka, avboka och söka resurser med hjälp av `ID` eller `Name`. Hur gör du detta utan att bryta mot principen om separering av ansvar?

### Konflikthantering vid bokning
- Vad händer om två användare försöker boka samma resurs samtidigt? Hur kan du använda trådsäkerhet för att hantera detta?

Lycka till med uppgiften! 😊