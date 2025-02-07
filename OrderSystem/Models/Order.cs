namespace OrderSystem.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsProcessed { get; set; }
}
