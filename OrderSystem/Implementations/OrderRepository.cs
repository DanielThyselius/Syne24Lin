using OrderSystem.Models;
using System;

public class OrderRepository
{
    public void Save(Order order)
    {
        // Simulate saving the order
        Console.WriteLine($"Order {order.Id} saved to the database.");
    }
}
