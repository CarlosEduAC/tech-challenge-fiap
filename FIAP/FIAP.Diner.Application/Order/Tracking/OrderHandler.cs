using FIAP.Diner.Application.Abstractions;
using FIAP.Diner.Domain.Order;

namespace FIAP.Diner.Application.Order.Tracking;

public class OrderHandler : ICommandHandler<RegisterOrderCommand>,
                            ICommandHandler<UpdateOrderTrackingCommand>
{
    private readonly IOrderRepository orderRepository;

    public OrderHandler(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task Handle(RegisterOrderCommand command, CancellationToken cancellation)
    {
        var order = new Domain.Order.Order(command.CartId, command.CustomerId);

        await orderRepository.Save(order);
    }

    public async Task Handle(UpdateOrderTrackingCommand command, CancellationToken cancellation)
    {
        var order = await orderRepository.Get(command.OrderId);

        if (order == null)
            throw new OrderTrackingNotFoundException(command.OrderId);

        order.UpdateStatus(command.OrderStatus);

        await orderRepository.Update(order);
    }
}