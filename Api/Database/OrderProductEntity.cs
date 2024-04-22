namespace Api.Database;

public class OrderProductEntity
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
