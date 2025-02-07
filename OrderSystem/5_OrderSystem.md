# Övning: Mocka flera beroenden i en beställningsprocess

## Scenario

Du ska testa en tjänst som hanterar en beställningsprocess (OrderProcessor). Tjänsten har flera beroenden som alla behöver mockas på olika sätt:

- **IOrderValidator**: Validerar att en order är korrekt.
- **IOrderRepository**: Sparar ordern i databasen.
- **INotificationService**: Skickar en notifiering om att ordern har behandlats.

Du ska skapa och testa OrderProcessor med hjälp av Moq för att isolera dessa beroenden.

## Kodsetup

### Interface för beroenden
Skapa dessa för att skapa en abstraktion att använda för mocking.

```csharp
public interface IOrderValidator
{
    bool Validate(Order order);
}

public interface IOrderRepository
{
    void Save(Order order);
}

public interface INotificationService
{
    void NotifyCustomer(Order order);
}
```

### Order-klass

```csharp
public class Order
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsProcessed { get; set; }
}
```

### OrderProcessor-tjänsten

Uppdatera denna för att använda våra nya interfaces.

```csharp
public class OrderProcessor
{
    private readonly IOrderValidator _validator;
    private readonly IOrderRepository _repository;
    private readonly INotificationService _notificationService;

    public OrderProcessor(IOrderValidator validator, IOrderRepository repository, INotificationService notificationService)
    {
        _validator = validator;
        _repository = repository;
        _notificationService = notificationService;
    }

    public void ProcessOrder(Order order)
    {
        if (!_validator.Validate(order))
        {
            throw new InvalidOperationException("Order is invalid.");
        }

        _repository.Save(order);

        order.IsProcessed = true;

        _notificationService.NotifyCustomer(order);
    }
}
```

## Uppgift

Skriv enhetstester för att säkerställa att OrderProcessor fungerar korrekt. Följande aspekter ska testas:

- **Mocka IOrderValidator**
  - Mocka så att `Validate()` returnerar både giltiga och ogiltiga resultat.
  - Verifiera att ett undantag kastas om ordern är ogiltig.

- **Mocka IOrderRepository**
  - Mocka så att `Save()` anropas korrekt med den order som behandlas.
  - Verifiera att `Save()` anropas exakt en gång.

- **Mocka INotificationService**
  - Mocka så att `NotifyCustomer()` anropas när ordern är behandlad.
  - Använd Callback för att spåra notifieringar eller inspektera argument.

- **Testa ordning på anrop**
  - Verifiera att `Validate`, `Save` och `NotifyCustomer` anropas i rätt ordning.

- **Mocka exceptionhantering i IOrderRepository**
  - Mocka så att `Save()` kastar ett undantag.
  - Verifiera att `NotifyCustomer()` inte anropas om ett undantag inträffar.

## Mål med övningen

- Förstå hur man använder Moq för att hantera flera beroenden.
- Lära sig att konfigurera olika typer av mockbeteenden (returvärden, exception, verifiering av anrop, ordning).
- Applicera mocks i ett verklighetstroget scenario med validering, datalagring och notifieringar.