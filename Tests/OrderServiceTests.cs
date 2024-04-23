using Api.Database;
using Api.Services;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests;

public class OrderServiceTests
{
    private OrderService _sut;
    private Mock<OrdersContext> _dbMock;

    [SetUp]
    public void Setup()
    {
        _dbMock = new Mock<OrdersContext>();
        var r = _dbMock.SetupGet(x => x.Orders).ReturnsDbSet(
        [
            new() {
                CompanyId = 1,
                Description = "Order 1",
                OrderProducts =
                [
                    new OrderProduct
                    {
                        ProductId = 1,
                        Price = 10,
                        Quantity = 2
                    },
                    new OrderProduct
                    {
                        ProductId = 2,
                        Price = 20,
                        Quantity = 1
                    }
                ]
            }

        ]);
        r.Verifiable();
        _sut = new OrderService(_dbMock.Object);
    }

    [Test]
    public async Task It_Displays_Correct_Order_Products()
    {
        var order = await _sut.GetOrdersForCompany(1);
        var firstOrder = order.First();
        Assert.Multiple(() =>
        {
            Assert.That(firstOrder.OrderProducts.Count(), Is.EqualTo(2));
            Assert.That(firstOrder.OrderProducts.First().Name, Is.EqualTo("Product 1"));
            Assert.That(firstOrder.OrderProducts.First().Price, Is.EqualTo(10));
            Assert.That(firstOrder.OrderProducts.First().Quantity, Is.EqualTo(2));
            Assert.That(firstOrder.OrderTotal, Is.EqualTo(30));
        });
    }

    [Test]
    public async Task Mock_Is_Called()
    {
        var _ = await _sut.GetOrdersForCompany(1);
        _dbMock.Verify(x => x.Orders, Times.Once());
    }
}
