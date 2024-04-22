using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Services;

namespace Api.Controllers
{

  [ApiController]
  [Route("api")]
  public class OrderController(IOrderService orderService) : ControllerBase
  {
    private readonly IOrderService _orderService = orderService;

    [HttpGet]
    [Route("order/{id}")]
    public async Task<IEnumerable<Order>> GetOrders(int id = 1)
    {
      return await _orderService.GetOrdersForCompany(id);
    }
  }
}
