using OrderSystem.Models;

public class OrderValidator
{
    public bool Validate(Order order)
    {
        // Simple validation logic
        return order != null && order.TotalAmount > 0;
    }
}
