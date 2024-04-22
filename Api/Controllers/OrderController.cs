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
    public IEnumerable<Order> GetOrders(int id = 1)
    {
      return _orderService.GetOrdersForCompany(id);
    }
  }
}
