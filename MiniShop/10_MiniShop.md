## Övningsuppgift: Generics, Exceptions och Lambdas

Nedan följer en mer omfattande övningsuppgift uppdelad i flera delmoment. Uppgiften är utformad för att ta ungefär en arbetsdag (8 timmar), men beroende på förkunskaper och ambitionsnivå kan det ta kortare eller längre tid.

Syftet är att:
1. Träna på att skapa och använda generiska klasser/metoder (Generics).  
2. Arbeta med olika typer av exceptions och egensnickrade undantagsklasser.  
3. Skriva och använda lambda-funktioner (anonyma funktioner).  
4. Eventuellt repetera Collections som en bonus.

Varje delmoment nedan har relativt detaljerade instruktioner, och avslutas med konkreta delmål eller “checkpoints”.  
På slutet finns några bonusmoment (utan lika detaljerade instruktioner) för den som blir klar snabbt.

---

### Översikt  
Ni ska bygga en liten “Mini-Shop”–applikation som hanterar produkter, kunder och beställningar. Fokus ligger på:  
• Att använda generiska klasser/metoder för att hantera era data.  
• Att fånga och kasta egna exceptions.  
• Att använda lambdas för filtrering och sortering m.m.

---

## Del 1: Projektuppsättning (Redan utfört om du stannar i denna repo)

1. Skapa en ny C# Console Application (nämn den t.ex. "MiniShop").  
2. Säkerställ att projektet bygger och kör (även om det inte gör något ännu).

<details>
  <summary><strong>Instruktioner steg-för-steg</strong></summary>

  1. Öppna valfri IDE (Visual Studio / VS Code).  
  2. Skapa en ny Console App (.NET).  
  3. Kontrollera att du kan kompilera och köra en enkel “Hello world”–kod.  
</details>

**Delmål**: Ha ett körbart tomt konsolprogram.  

---

## Del 2: Generisk Repository

Ni ska skapa en generisk “Repository”–klass som kan hantera olika typer av objekt (t.ex. produkter, kunder).

1. Skapa ett generiskt interface `IRepository<T>` med följande metoder:  
   - `void Add(T item)`  
   - `T GetById(int id)`  
   - `IEnumerable<T> GetAll()`  
2. Skapa en generisk klass `GenericRepository<T>` som implementerar `IRepository<T>`.  
   - Internt kan den använda en `List<T>` för att lagra objekten.  
   - I denna övning kan du anta att ditt `T`-objekt har en egenskap “Id” av typen int, så att `GetById` kan hitta rätt objekt.  
3. Skapa enkla klasser för “Product” och “Customer”, båda med en `public int Id { get; set; }`, för att möjliggöra användning i ditt repository.  
   - Lägg till åtminstone någon mer egenskap, t.ex. “Name” för Product och “Email” för Customer.

<details>
  <summary><strong>Instruktioner steg-för-steg</strong></summary>

  1. Skapa en mapp “Repositories” eller liknande.  
  2. Skapa filen “IRepository.cs” med interfacet.  
  3. Skapa filen “GenericRepository.cs” med klassen.  
  4. Skapa en mapp “Models” eller liknande för “Product.cs” och “Customer.cs”.  
  5. I “GenericRepository” definiera en privat lista:  
     <pre><code>private List&lt;T&gt; items = new List&lt;T&gt;();
     </code></pre>
  6. Implementera Add, GetById, GetAll. För GetById, iterera över listan och hitta elementet vars “Id” matchar. Anta för enkelhets skull att “Id” finns genom reflection eller att “T” implementerar ett interface “IHasId” med en “Id”-property.  
</details>

**Delmål**: Kunna skapa ett “GenericRepository<Product>” och lägga till produkter samt hämta dem.  

---

## Del 3: Generics & Constraints

Nu vill vi kontrollera att de klasser vi skickar in till vår generiska repository faktiskt har en Id-egenskap, så att `GetById` fungerar korrekt.

1. Skapa ett interface `IHasId` med en property:
   ```csharp
   public interface IHasId
   {
       int Id { get; set; }
   }
   ```
2. Låt `Product` och `Customer` implementera `IHasId`.  
3. Ändra `GenericRepository<T>` så att den har en constraint på “T: IHasId”.  
   - Detta gör att “T” garanterat har en egenskap “Id”.  

<details>
  <summary><strong>Instruktioner steg-för-steg</strong></summary>

  1. Öppna filen “IHasId.cs” och definiera `int Id {get; set;}`.  
  2. Publicera i “Product.cs” och “Customer.cs” att de implementerar `IHasId`.  
  3. I “GenericRepository<T>” skriv:  
     <pre><code>public class GenericRepository&lt;T&gt; : IRepository&lt;T&gt; 
         where T : IHasId
     </code></pre>
  4. Du kan nu i `GetById(int id)` direkt skriva:  
     <pre><code>return items.FirstOrDefault(x => x.Id == id);
     </code></pre>
     med en lambda (se Del 5 nedan).
</details>

**Delmål**: Säkra att man inte kan använda `GenericRepository` med en klass som saknar “Id”.

---

## Del 4: Exceptions

Ni ska nu lägga till felhantering i er kod. Om någon försöker hämta ett objekt med en ogiltig eller obefintlig Id, vill vi antingen returnera `null` eller kasta ett exceptions.

1. Skapa en custom exception “ItemNotFoundException : Exception”.  
2. Ändra `GetById(int id)` i `GenericRepository<T>`:  
   - Om objektet inte hittas, kasta “ItemNotFoundException” med ett vettigt felmeddelande, t.ex. “No item with id {id} found.”  
3. Testa att ni kan fånga detta undantag i en `try-catch`:

   ```csharp
   try
   {
       var product = productRepo.GetById(999); // Finns ej
   }
   catch (ItemNotFoundException ex)
   {
       Console.WriteLine(ex.Message);
   }
   ```

<details>
  <summary><strong>Instruktioner steg-för-steg</strong></summary>

  1. Skapa filen “ItemNotFoundException.cs”.  
  2. Låt den ärva från `Exception` och ha en konstruktor som tar in `string message`.  
  3. I `GetById`–metoden, använd “FirstOrDefault”. Om resultatet är `null`, kasta undantaget:  
     <pre><code>if (foundItem == null)
     {
         throw new ItemNotFoundException($"No item with id {id} found.");
     }
     </code></pre>
  4. Testa anropet i “Program.cs”. Skriv ut felmeddelandet i console (eller debugger).
</details>

**Delmål**: Vara bekväm med att designa, kasta och fånga egna exceptions.

---

## Del 5: Lambdas

Ni ska nu använda lambdas för att filtrera och manipulera datan i era repositories.

1. Inuti `GenericRepository<T>`, lägg till en metod `IEnumerable<T> Filter(Func<T, bool> predicate)` som returnerar alla objekt i “items” där `predicate` är `true`.  
2. Testa i “Program.cs”:  
   - Skapa en lista med `Product`–objekt.  
   - Filtrera fram de produkter vars namn börjar på “A” (tips: `product.Name.StartsWith("A")`).  
3. Använd gärna `.Where(...)` från LINQ för att implementera `Filter`.

<details>
  <summary><strong>Instruktioner steg-för-steg</strong></summary>

  1. Lägg till using `System.Linq`.  
  2. Skapa en ny metod i “GenericRepository”:  
     <pre><code>public IEnumerable&lt;T&gt; Filter(Func&lt;T, bool&gt; predicate)
     {
         return items.Where(predicate);
     }
     </code></pre>
  3. I “Program.cs”:
     <pre><code>var filteredProducts = productRepo.Filter(p => p.Name.StartsWith("A"));
     foreach(var prod in filteredProducts)
     {
         Console.WriteLine(prod.Name);
     }
     </code></pre>
  4. Lägg till minst några produkter (ex “Apple”, “Avocado”, “Banana”) så att ni kan se effekten.
</details>

**Delmål**: Träna på lambdas och deras användning i LINQ.

---

## Del 6: Sammanför allting

Nu ska ni bygga ut er “Mini-Shop”–applikation och demonstrera följande funktionalitet i “Program.cs”:

1. Skapa två repository–instanser: `productRepo` och `customerRepo`.  
2. Lägg till minst fem produkter och tre kunder.  
3. Försök hämta en produkt med ogiltig Id och se till att ni fångar `ItemNotFoundException`.  
4. Använd `Filter`–metoden för att filtrera listan (till exempel alla produkter som kostar mer än 100 kr, om ni lägger till en `Price`–egenskap).  
5. Skriv ut resultatet i konsolen.

**Delmål**: Ha en körbar applikation där man tydligt ser hur generics, exceptions och lambdas används i samverkan.

---

## Bonusövningar (frivilliga)

1. **Sortering (Lambda i LINQ)**  
   Skapa en metod `IEnumerable<T> SortBy<TKey>(Func<T, TKey> keySelector)` i `GenericRepository<T>`. Låt den sortera listan med `.OrderBy(keySelector)`.  
   • Testa att sortera dina produkter efter pris, eller kunder efter namn.

2. **Fler exceptions**  
   Bygg en `ValidateCustomer(Customer c)`–metod som kastar en egen `InvalidCustomerDataException` om kundens `Email` är tom eller felaktig. Testa metoden när du lägger till nya kunder i `customerRepo`.

3. **Concurrent Collections**  
   Om du är intresserad av trådsäkerhet kan du byta ut din interna `List<T>` i `GenericRepository<T>` mot en `ConcurrentBag<T>`. Diskutera för- och nackdelar.

4. **Enhetstester**  
   Om du är bekväm med testprojekt (t.ex. xUnit): skriv en testklass “ProductRepositoryTests” där du testar att undantag kastas korrekt, att filterfunktionen fungerar, osv.

---

## Checklista

Gå igenom följande checklista innan du lämnar in:

1. [ ] Har du skapat minst två klasser (Product, Customer) som implementerar `IHasId`?  
2. [ ] Har du en generisk klass `GenericRepository<T>` med constraint `T : IHasId`?  
3. [ ] Har du implementerat metoderna `Add`, `GetById`, `Filter`?  
4. [ ] Kastas “ItemNotFoundException” om item inte hittas i `GetById`?  
5. [ ] Fångas felet med `try-catch` i `Program.cs`?  
6. [ ] Använder du minst en lambda-funktion i `Filter`?  
7. [ ] Har du en tydlig main-metod som demonstrerar allt ovan?  

Om alla punkter är uppfyllda har du genomfört övningen. Diskutera gärna i grupp hur ni tyckte uppgifterna fungerade. 

---

## Avslutande ord

• Den här uppgiften är relativt öppen, så det går bra att ändra i designen om ni vill – men behåll gärna huvuddelarna: generics, exceptions och lambdas.  
• Ta tid på er och se till att ni verkligen förstår hur generics, exceptions och lambdas hänger ihop.  
• Om ni fastnar eller har frågor: diskutera i par/grupp och googla efter kodmönster – men försök först själv!  

Lycka till med programmerandet!