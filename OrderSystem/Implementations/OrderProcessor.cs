using OrderSystem.Models;
using System;

public class OrderProcessor
{
    private readonly OrderValidator _validator;
    private readonly OrderRepository _repository;
    private readonly NotificationService _notificationService;

    public OrderProcessor(OrderValidator validator, OrderRepository repository, NotificationService notificationService)
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
