using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database;

[Table("Order")]
public class OrderEntity
{
    [Column("order_id")]
    public int OrderId { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("company_id")]
    public int CompanyId { get; set; }
}
