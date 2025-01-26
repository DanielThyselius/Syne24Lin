# **Övning: Implementera och Testa en TextAnalyzer med xUnit**

I denna övning ska du skapa en klass som analyserar en text och implementera två metoder för att räkna ord och bokstäver. Därefter ska du skriva enhetstester med xUnit för att verifiera att din implementation fungerar korrekt.

---

## **Instruktioner**

### **1. Förstå `TextAnalyzer**

1. Läs igenom den tillhandahållna klassen `TextAnalyzer` i [denna](../TextAnalyzer.md) fil.
2. Förstå följande metoder i klassen:
   - `CountWords(string text)`: Returnerar antalet ord i den angivna strängen.
   - `CountLetters(string text)`: Returnerar antalet bokstäver (exklusive blanksteg och skiljetecken) i den angivna strängen.
3. Analysera hur metoderna använder C#-funktioner för att dela upp texten och räkna bokstäver respektive ord.

---

### **2. Skapa ett testprojekt**
2. Lägg till ett nytt klassbibliotek `Library.Test` för tester.
3. Lägg till en referens från `Library.Test` till `Library`.
4. Installera xUnit nugetpaket i `Library.Test`.

---

### **3. Skriv enhetstester**

1. Skapa en ny klass med namnet `TextAnalyzerTests` i testprojektet.
2. Lägg till tester för följande scenarier:

#### **Test 1: Verifiera ordräkning**
- Testa att `CountWords` returnerar rätt antal ord för olika typer av indata:
  - En enkel mening, exempelvis två ord.
  - En mening med flera mellanslag.
  - En tom sträng.
  - Vad med? (hint: testa strängen ",,")

#### **Test 2: Verifiera bokstavsräkning**
- Testa att `CountLetters` returnerar rätt antal bokstäver för olika typer av indata:
  - En enkel mening utan specialtecken.
  - En mening med specialtecken och skiljetecken.
  - En tom sträng.
  - Kan du komma på fler specialfall?

#### **Test 3: Verifiera tomma eller null-strängar**
- Testa att både `CountWords` och `CountLetters` returnerar `0` när texten är tom eller `null`.

3. Kör dina tester och säkerställ att alla passerar.

---

## **Extra Utmaningar**
Om du har tid över, utöka funktionaliteten och skriv fler tester:
1. **Ignorera siffror i CountLetters:**  
  Exempelvis "Hello123" ska endast räkna bokstäverna och returnera 5.
2. **Räkna specifika bokstäver:**  
  Lägg till en metod CountSpecificLetter(string text, char letter) som räknar antalet förekomster av en viss bokstav (skiftlägeskänsligt).
3. **Räkna unika ord:**  
  Lägg till en metod CountUniqueWords(string text) som räknar antalet unika ord i en sträng.
4. **Implementera Meningsräkning:**  
  Utöka `TextAnalyzer`-klassen med en metod `CountSentences(string text)` som returnerar antalet meningar i den angivna strängen. Tänk på olika meningsavslutande skiljetecken som punkt, utropstecken och frågetecken.
5. **Lägg till Språkdetektion:**  
  Implementera en enkel språkdetektionsfunktion i `TextAnalyzer`-klassen. Använd grundläggande heuristik för att avgöra om texten huvudsakligen är på engelska eller ett annat språk, baserat på vanliga ord eller tecken.

---

## **Sammanfattning och Reflektion**

- Vi har skapat en klass `TextAnalyzer` som implementerar metoder för att räkna ord och bokstäver.
- Du har skrivit enhetstester med xUnit för att validera funktionaliteten.
- Du har tränat på att hantera olika scenarier, inklusive tomma och null-strängar.

### Analyserande Frågor

**Fråga 1:**  
Ser du några problem med att testa med så många olika scenarion? Hur kommer detta skala i längden?

**Fråga 2:**  
Hur kan tester hjälpa dig att utveckla ny funktionalitet eller ändra befintlig kod?

**Fråga 3:**  
Hur kan designen av din kod påverka hur lätt det är att skriva och underhålla tester?

