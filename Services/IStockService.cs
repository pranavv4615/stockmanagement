using System;
using System.Collections.Generic;

public interface IStockService
{
    List<Stock> GetAllStocks();
    Stock GetStockById(int id);
    void AddStock(Stock stock);
    void UpdateStock(Stock stock);
    void DeleteStock(int id);
    bool CheckStockAvailability(int stockId, int orderQty);
    void UpdateStockQuantity(int stockId, int quantityChange);
}
