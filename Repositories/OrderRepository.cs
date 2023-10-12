using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace StockOrderManagement.Data;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }

    public Order GetOrderById(int id)
    {
        return _context.Orders.FirstOrDefault(o => o.Id == id);
    }

    public void AddOrder(Order order)
    {
        _context.Orders.Add(order);

        // You may want to include error handling and validation here.

        _context.SaveChanges();
    }

    public void UpdateOrder(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;

        // You may want to include error handling and validation here.

        _context.SaveChanges();
    }

    public void DeleteOrder(int id)
    {
        var order = GetOrderById(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
