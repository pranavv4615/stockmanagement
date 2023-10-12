using System;
using System.Collections.Generic;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public List<Stock> GetAllStocks()
    {
        return _stockRepository.GetAllStocks();
    }

    public Stock GetStockById(int id)
    {
        return _stockRepository.GetStockById(id);
    }

    public void AddStock(Stock stock)
    {
        // Implement validation logic here, e.g., check for duplicates, required fields, etc.
        _stockRepository.AddStock(stock);
    }

    public void UpdateStock(Stock stock)
    {
        // Implement update logic here.
        _stockRepository.UpdateStock(stock);
    }

    public void DeleteStock(int id)
    {
        var stock = GetStockById(id);
        if (stock != null)
        {
            if (stock.OrderValue == 0)
            {
                _stockRepository.DeleteStock(id);
            }
            else
            {
                throw new InvalidOperationException("Stock with non-zero order value cannot be deleted.");
            }
        }
        else
        {
            throw new InvalidOperationException("Stock not found.");
        }
    }

    public bool CheckStockAvailability(int stockId, int orderQty)
    {
        var stock = GetStockById(stockId);
        if (stock != null && stock.Quantity >= orderQty)
        {
            return true;
        }
        return false;
    }

    public void UpdateStockQuantity(int stockId, int quantityChange)
    {
        var stock = GetStockById(stockId);
        if (stock != null)
        {
            stock.Quantity += quantityChange;
            _stockRepository.UpdateStock(stock);
        }
        else
        {
            throw new InvalidOperationException("Stock not found.");
        }
    }

    // You can add additional methods for your specific requirements here.
}
