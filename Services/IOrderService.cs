using System;
using System.Collections.Generic;

public interface IOrderService
{
    List<Order> GetAllOrders();
    Order GetOrderById(int id);
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(int id);
}
