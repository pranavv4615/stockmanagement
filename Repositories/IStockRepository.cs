using System.Collections.Generic;

public interface IStockRepository
{
    Stock GetStockById(int id);
    List<Stock> GetAllStocks();
    void AddStock(Stock stock);
    void UpdateStock(Stock stock);
    void DeleteStock(int id);
}
