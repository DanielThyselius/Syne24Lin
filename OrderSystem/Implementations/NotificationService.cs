using OrderSystem.Models;
using System;

public class NotificationService
{
    public void NotifyCustomer(Order order)
    {
        // Simulate sending a notification
        Console.WriteLine($"Notification sent to {order.CustomerEmail} for order {order.Id}.");
    }
}
