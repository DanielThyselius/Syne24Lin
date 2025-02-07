using System;
using OrderSystem.Models;

class Program
{
    static void Main(string[] args)
    {
        var order = new Order { Id = 1, CustomerEmail = "customer@example.com", TotalAmount = 150m };

        var validator = new OrderValidator();
        var repository = new OrderRepository();
        var notificationService = new NotificationService();

        var processor = new OrderProcessor(validator, repository, notificationService);

        try
        {
            processor.ProcessOrder(order);
            Console.WriteLine("Order processed successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Order processing failed: {ex.Message}");
        }
    }
}
