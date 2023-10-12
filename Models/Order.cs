using StockOrderManagement.Models;
public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public int StockId { get; set; }
    public int OrderQty { get; set; }
}