using FIAP.Diner.Domain.Abstractions;

namespace FIAP.Diner.Domain.Order;

public class OrderTracking : Entity<OrderTrackingId>
{
    public OrderTracking(OrderStatus orderStatus)
    {
        Id = Guid.NewGuid();
        OrderStatus = orderStatus;
        DateTime = DateTime.Now;
    }

    public OrderStatus OrderStatus { get; private set; }
    public DateTime DateTime { get; }
}