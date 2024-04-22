using System.Data;
using Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{

    public class OrderService(OrdersContext db) : IOrderService
    {
        private readonly OrdersContext _orderRepository = db;

        public async Task<IEnumerable<Models.Order>> GetOrdersForCompany(int CompanyId)
        {
            var result = await _orderRepository
                .Orders
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product)
                .Include(x => x.Company)
                .Where(o => o.CompanyId == CompanyId)
                .ToListAsync();

            return result.Select(x => new Models.Order
            {
                CompanyName = x.Company.Name,
                Description = x.Description,
                OrderProducts = x.OrderProducts.Select(x => new Models.Product
                {
                    Name = x.Product.Name,
                    Price = x.Price,
                    Quantity = x.Quantity
                }),
                OrderTotal = x.OrderProducts.Select(x => x.Price * x.Quantity).Sum()
            });
        }
    }
}
