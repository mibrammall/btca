namespace Api.Database;

public class OrderProductEntity
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
