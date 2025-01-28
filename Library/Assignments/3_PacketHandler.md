# Paket- och Prishantering: Skapa ett Program med Enhetstester

I denna uppgift ska du skapa ett program för att hantera paket och rör, beräkna deras volym och pris, och senare utöka programmet med mer avancerade funktioner som rabatter, batchhantering och transportkostnader. Du kommer använda enhetstester för att säkerställa att beräkningarna är korrekta och lära dig arbeta med data-drivna tester.

## Mål med uppgiften
- Skapa en ny klass för de olika paket-typerna: paket (rätblock) och rör (cylindrar).
- Användaren ska kunna mata in dimensioner och vikt.
- Programmet ska beräkna volym och pris för varje paket/rör.
- Använd arv eller komposition för att uppnå polymorphism.
- Implementera och använda enhetstester för att validera funktionaliteten.

## Grundläggande Funktionalitet

### 1. Paket (rätblock)
- **Volymberäkning:**  
  Volym = längd × bredd × höjd (i cm³).
- **Prisberäkning:**  
  Pris = kortaste sidan (cm) × längsta sidan (cm) × vikt (kg) + 10000 (öre).
- **Specialpriser:**  
  Om längsta sidan < 30 cm:
  - Upp till 2 kg: 29 kr.
  - 2–10 kg: 49 kr.
  - 10–20 kg: 79 kr.

### 2. Rör (cylindrar)
- **Volymberäkning:**  
  Volym = π × radie² × längd (i cm³).  
  Radie = diameter / 2.
- **Prisberäkning:**  
  Pris = omkrets (cm) × längd (cm) × vikt (kg).  
  Minsta vikt som används i beräkningen är 2 kg (även om vikten är mindre).

### 3. Maxvikt
- Maxvikt för alla paket och rör är 20 kg. Om vikten överstiger detta, ska programmet ge ett felmeddelande och inte göra några beräkningar.

## Enhetstester för Grundfunktionalitet
- Testa volymberäkningar för både paket och rör.
- Testa prisberäkningar enligt specifikationen.
- Testa att maxvikt hanteras korrekt (felmeddelande vid övervikt).
- Testa specialpriser för små paket med längsta sidan < 30 cm.
- Se om du kan komma på fler specialfall som behöver testas. 

## Arbetssätt
1. **Designa din kod för testbarhet**  
   Separera beräkningslogiken i små, återanvändbara metoder eller klasser.  
   Använd objektorienterade principer, t.ex., skapa separata klasser för paket och rör.
2. **Använd data-drivna tester**  
   Använd data-drivna tester för att täcka olika scenarier:
   - Prisberäkningar med olika vikt, dimensioner och pakettyper.
   - Rabatter baserat på olika villkor.
   - Transportkostnader med varierande sträckor.
3. **(Valfri) Skriv tester först (TDD)**  
   Testa att skriva tester innan du implementerar funktionerna, detta kallas Test Driven Development (TDD), och kommer vara ämnet på nästa föreläsning.  
   Kör tester kontinuerligt för att validera att ditt program fungerar korrekt.

## Extra Utmaningar: Utökad Funktionalitet
När du är klar med grunduppgiften kan du implementera och testa följande utökade funktioner.

### 1. Rabatt/Kampanjkoder
- **Beskrivning:**  
  Lägg till stöd för rabattkoder som ger en procentsats rabatt (t.ex., 10% rabatt).
- **Villkor för rabattkoder:**  
  Rabattkoder kan begränsas till vissa typer av paket (t.ex., bara rör eller paket).  
  Rabattkoder kan också begränsas till paket/rör med specifika vikter eller dimensioner.

### 2. Batch-hantering
- **Beskrivning:**  
  Låt användaren lägga till flera paket och rör samtidigt (en batch).  
  Beräkna totalpriset för hela batchen.
- **Implementera en mängdrabatt:**  
  T.ex., om användaren skickar fler än 5 paket eller rör, ge 10% rabatt på totalpriset.

### 3. Transportsträcka
- **Beskrivning:**  
  Låt användaren mata in transportsträckan (i kilometer) för varje paket/rör.
- **Anpassa priset baserat på sträckan:**  
  Lägg till en transportkostnad på t.ex. 1 kr per kilometer till baspriset.

## Reflektion
När du är klar, reflektera över följande frågor:
- Hur hjälpte data-drivna tester dig att hantera olika scenarier?
- Hur påverkade din koddesign möjligheten att lägga till nya funktioner?
- Vad skulle du ändra i ditt arbetssätt för att förenkla framtida utveckling?