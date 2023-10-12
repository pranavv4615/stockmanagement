using System;
using System.Collections.Generic;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public List<Order> GetAllOrders()
    {
        return _orderRepository.GetAllOrders();
    }

    public Order GetOrderById(int id)
    {
        return _orderRepository.GetOrderById(id);
    }

    public void AddOrder(Order order)
    {
        // Implement validation logic here.
        _orderRepository.AddOrder(order);
    }

    public void UpdateOrder(Order order)
    {
        // Implement update logic here.
        _orderRepository.UpdateOrder(order);
    }

    public void DeleteOrder(int id)
    {
        var order = GetOrderById(id);
        if (order != null)
        {
            _orderRepository.DeleteOrder(id);
        }
        else
        {
            throw new InvalidOperationException("Order not found.");
        }
    }

    // You can add additional methods for your specific requirements here.
}
