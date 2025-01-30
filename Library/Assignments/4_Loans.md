# Övning: Bibliotekshantering med Enhetstester

I denna uppgift ska du lägga till lån och förseningsavgifter i ditt system. Uppgiften syftar till att simulera ett bibliotekssystem där olika mediatyper kan lånas ut, och förseningsavgifter beräknas baserat på låneperiod och mediatyp. **Uppgiften ska utföras enligt TDD (Test-Driven Development).**

## Mål
- Använd befintliga klasser och objekt för att låna ut.
- Skapa en klass som representerar ett lån.
- Beräkna förseningsavgifter baserat på mediatyp och förseningstid

### Mediatyper
- **Book**
  - Låneperiod: 21 dagar
  - Förseningsavgift: 10 kr/dag
  - Maxavgift: 300 kr (30+ dagar)
- **Computer**
  - Låneperiod: 7 dagar
  - Förseningsavgift: 20 kr/dag
  - Ingen maxavgift
- **Room**
  - Låneperiod: 1 dag
  - Förseningsavgift: 150 kr/dag
  - Maxavgift: 3000 kr (20+ dagar)

### Enhetstester
- Testa avgiftsberäkning för alla mediatyper
- Testa maxavgiftsgränser
- Testa hantering av negativa förseningsdagar

## Mål steg 2
- Implementera medlemshantering med olika förmåner
- Använd arv/komposition för polymorfism
- Skriv enhetstester som validerar alla krav

### Medlemmar
- **Standardmedlem**: Max 5 lån samtidigt
- **Premiummedlem**: Max 10 lån, 10% rabatt på förseningsavgifter

### Enhetstester
- Testa medlemsrabatter
- Testa lånegränser

## Mål steg 3

Lägg till fler mediatyper och implementera avgiftsberäkning.

## Mediatyper
- **DVD**
  - Låneperiod: 2 dagar
  - Förseningsavgift: 20 kr/dag
  - Maxavgift: 200 kr (10+ dagar)
- **Audiobook**
  - Låneperiod: 60 dagar
  - Förseningsavgift: 5 kr/dag
  - Maxavgift: 300 kr (60+ dagar)

## Extra Utmaningar
- **Kampanjkoder**
  - "FRI50": 50 kr avdrag
  - "PCHALVA": 50% rabatt på PC-avgifter
- **Grupplån**
  - 3+ media samtidigt: 15% rabatt på total avgift
  - Kombinera med medlemsrabatter
- **Leveranskostnader**
  - Hemleverans: +50 kr
  - Fri leverans för premiummedlemmar

## Avancerade Utmaningar
Vi använder nu en Abstract class och ett interface för att implementera bokning. Hur kan vi förenkla detta?
- Lös TODO:s i koden genom att refaktorera och optimera.
- Skapa en fork av projektet och gör ett PR med dina förbättringar.
- Diskutera vad som utgör en bra lösning och varför.

## Reflektionsfrågor
- Vilka testfall blev oväntat komplexa, och hur hanterade du dessa?
- Vad var svårast att testa, och varför?
- Just nu använder vi en Abstract class och ett interface för att implementera bokning. Varför är detta inte optimalt i detta fallet, och hur kan det förbättras?
