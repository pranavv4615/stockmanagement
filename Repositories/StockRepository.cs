using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StockOrderManagement.Data;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _context;

    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Stock> GetAllStocks()
    {
        return _context.Stocks.ToList();
    }

    public Stock GetStockById(int id)
    {
        return _context.Stocks.FirstOrDefault(s => s.Id == id);
    }

    public void AddStock(Stock stock)
    {
        _context.Stocks.Add(stock);
        _context.SaveChanges();
    }

    public void UpdateStock(Stock stock)
    {
        _context.Entry(stock).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteStock(int id)
    {
        var stock = GetStockById(id);
        if (stock != null)
        {
            _context.Stocks.Remove(stock);
            _context.SaveChanges();
        }
    }
}
