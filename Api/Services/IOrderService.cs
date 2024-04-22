using Api.Models;

namespace Api.Services;

public interface IOrderService
{
    Task<List<Order>> GetOrdersForCompany(int CompanyId);
}
