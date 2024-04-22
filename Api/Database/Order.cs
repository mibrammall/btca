namespace Api.Database;

public partial class Order
{
    public int OrderId { get; set; }

    public string Description { get; set; } = null!;

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
