# Övningsuppgifter: Arrayer i C#

## Del 1: Sorteringsalgoritmer

### 1. Bubble Sort
Bubble Sort är en enkel sorteringsalgoritm som upprepade gånger går igenom listan och jämför intilliggande element.

**Algoritmen fungerar så här:**
1. Börja från början av arrayen
2. Jämför element[0] med element[1]
3. Om element[0] > element[1], byt plats på dem
4. Fortsätt med element[1] och element[2], osv.
5. När slutet nås, börja om från början
6. Upprepa tills inga byten behövs

```csharp
public static void BubbleSort(int[] array)
{
    // Implementera bubble sort enligt stegen ovan
    // Tips: Du behöver två nästlade for-loopar
    // Tips: Använd en temp-variabel för att byta plats på element
}
```

### 2. Selection Sort
Selection Sort är en enkel sorteringsalgoritm som delar upp arrayen i en sorterad och en osorterad del.

**Algoritmen fungerar så här:**
1. Hitta det minsta elementet i den osorterade delen
2. Byt plats på det med första elementet i den osorterade delen
3. Flytta gränsen mellan sorterad/osorterad del ett steg åt höger
4. Upprepa tills hela arrayen är sorterad

```csharp
public static void SelectionSort(int[] array)
{
    // Implementera selection sort enligt stegen ovan
    // Tips: Du behöver två nästlade for-loopar
    // Tips: Håll reda på index för minsta värdet
}
```

**Exempel på processen:**
```csharp
[5,3,1,4,2] → [1,3,5,4,2] → [1,2,5,4,3] → [1,2,3,4,5]
  ^                ^              ^
minsta            minsta         minsta

Förklaring:
1. Hitta 1 (minst), byt med 5
2. Hitta 2 (minst i återstående), byt med 3
3. Hitta 3 (minst i återstående), byt med 5
4. Hitta 4 (minst i återstående), redan på rätt plats
5. Klar!
```

### Testexempel
```csharp
// Testa dina implementationer:
int[] test = { 64, 34, 25, 12, 22, 11, 90 };

Console.WriteLine("Före Bubble Sort:");
Console.WriteLine(string.Join(", ", test));

BubbleSort(test);
Console.WriteLine("Efter Bubble Sort:");
Console.WriteLine(string.Join(", ", test));

test = new int[] { 64, 34, 25, 12, 22, 11, 90 };
SelectionSort(test);
Console.WriteLine("Efter Selection Sort:");
Console.WriteLine(string.Join(", ", test));
```

### Tips för implementationen
- **Bubble Sort:**
  - Använd en boolean för att hålla koll på om några byten gjorts
  - Optimera genom att minska antalet iterationer för varje genomgång
  
- **Selection Sort:**
  - Håll reda på index för minsta värdet i den osorterade delen
  - Använd en variabel för att markera gränsen mellan sorterad/osorterad del
  - Kom ihåg att byta plats på elementen när minsta värdet hittats

## Del 2: Range-operatorer
Skapa en klass `ArraySplitter` med följande metoder:

```csharp
public class ArraySplitter
{
    // Dela array i två delar och returnera summan av respektive del
    // Exempel: [1,2,3,4] -> första halvan = 3 (1+2), andra halvan = 7 (3+4)
    public (int firstHalf, int secondHalf) SumHalves(int[] numbers)
    {
        // Din kod här (använd range-operator)
    }

    // Ta bort första och sista elementet och returnera mittenpartiet
    // Exempel: [1,2,3,4,5] -> [2,3,4]
    public int[] GetMiddleSection(int[] numbers)
    {
        // Din kod här (använd range-operator)
    }
}
```

## Del 3: Flerdimensionella arrayer
Implementera ett enkelt rutnät för tre-i-rad:

```csharp
public class TicTacToe
{
    private char[,] board;

    public TicTacToe()
    {
        // Initiera ett 3x3 rutnät med tomma platser (' ')
    }

    // Placera 'X' eller 'O' på position (row, col)
    // Returnera false om draget är ogiltigt
    public bool MakeMove(int row, int col, char player)
    {
        // Din kod här
    }

    // Kontrollera om någon har vunnit
    // Returnera 'X', 'O' eller ' ' (ingen vinnare)
    public char CheckWinner()
    {
        // Din kod här
    }

    // Skriv ut spelplanen
    public void PrintBoard()
    {
        // Din kod här
    }
}
```

## Bonusuppgifter: 
### 1. Jagged Arrays
Implementera en metod som skapar en "triangelformad" jagged array:

```csharp
// Skapa en triangelformad array där varje rad är en längre än föregående
// Exempel: rows = 3 ger:
// [1]
// [2, 2]
// [3, 3, 3]
public static int[][] CreateTriangle(int rows)
{
    // Din kod här
}
```

### 2. Merge Sort
Merge Sort använder "dela och härska"-principen genom att dela arrayen i mindre delar, sortera dem och sedan slå ihop dem.

**Algoritmen fungerar så här:**
1. **Dela (Split):**
   - Dela arrayen i två halvor
   - Fortsätt dela rekursivt tills varje del har 1 element
2. **Härska (Sort):**
   - En array med 1 element är redan sorterad
3. **Kombinera (Merge):**
   - Slå ihop två sorterade arrayer till en sorterad array
   - Jämför element från båda arrayerna och sätt in det mindre först

```csharp
public class MergeSort
{
    public static void Sort(int[] array)
    {
        // Huvudmetod som startar sorteringen
        // Tips: Anropa MergeSortRecursive med hela arrayen
    }

    private static void MergeSortRecursive(int[] array, int start, int end)
    {
        // Rekursiv metod som delar arrayen
        // Tips: Hitta mitten med (start + end) / 2
        // Tips: Anropa rekursivt för båda halvor
        // Tips: Använd Merge för att slå ihop resultaten
    }

    private static void Merge(int[] array, int start, int middle, int end)
    {
        // Slå ihop två sorterade delar av arrayen
        // Tips: Skapa temporära arrayer för vänster och höger del
        // Tips: Jämför och sätt in element i rätt ordning
    }
}
```

**Exempel på merge-steget:**
```csharp
Vänster: [1,3,5]
Höger:  [2,4,6]
Merge:  [1,2,3,4,5,6]
```

**Visualisering av hela processen:**
```
          [3,1,4,2]
         /          \
    [3,1]            [4,2]
   /      \         /      \
[3]        [1]   [4]        [2]
   \      /         \      /
    [1,3]            [2,4]
         \          /
          [1,2,3,4]
```


## Tips
- Testa dina implementationer med olika input
- Hantera kantfall (tom array, ogiltig input, etc.)
- Använd debuggern för att följa programflödet
- Skriv tester för att verifiera din kod

## Utmaningar
- Implementera diagonalkontroll i tre-i-rad
- Lägg till felhantering med exceptions
- Optimera kodprestanda där möjligt
