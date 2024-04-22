using System.Data;
using Api.Database;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{

    public class OrderService(OrdersContext db) : IOrderService
    {
        private readonly OrdersContext _orderRepository = db;

        public async Task<IEnumerable<Order>> GetOrdersForCompany(int CompanyId)
        {
            var result = await _orderRepository.Orders.Where(o => o.CompanyId == CompanyId).ToListAsync();

            return result.Select(x => new Order
            {
                CompanyName = x.CompanyId.ToString()
            });

            // //Get the order products
            // var sql2 =
            //     "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            // var reader2 = database.ExecuteReader(sql2);

            // var values2 = new List<OrderProduct>();

            // while (reader2.Read())
            // {
            //     var record2 = (IDataRecord)reader2;

            //     values2.Add(new OrderProduct()
            //     {
            //         OrderId = record2.GetInt32(1),
            //         ProductId = record2.GetInt32(2),
            //         Price = record2.GetDecimal(0),
            //         Quantity = record2.GetInt32(3),
            //         Product = new Product()
            //         {
            //             Name = record2.GetString(4),
            //             Price = record2.GetDecimal(5)
            //         }
            //     });
            // }

            // reader2.Close();

            // foreach (var order in values)
            // {
            //     foreach (var orderproduct in values2)
            //     {
            //         if (orderproduct.OrderId != order.OrderId)
            //             continue;

            //         order.OrderProducts.Add(orderproduct);
            //         order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
            //     }
            // }
        }
    }
}
