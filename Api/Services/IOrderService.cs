using Api.Models;

namespace Api.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrdersForCompany(int CompanyId);
}
