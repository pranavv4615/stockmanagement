using Microsoft.AspNetCore.Mvc;
using StockOrderManagement.Models;
namespace StockOrderManagement.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IStockService _stockService;

    public OrderController(IOrderService orderService, IStockService stockService)
    {
        _orderService = orderService;
        _stockService = stockService;
    }

    public IActionResult Index()
    {
        var orders = _orderService.GetAllOrders();
        return View(orders);
    }

    public IActionResult Create()
    {
        var stocks = _stockService.GetAllStocks();
        ViewBag.StockList = new SelectList(stocks, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (ModelState.IsValid)
        {
            if (_stockService.CheckStockAvailability(order.StockId, order.OrderQty))
            {
                _orderService.AddOrder(order);
                _stockService.UpdateStockQuantity(order.StockId, -order.OrderQty);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("OrderQty", "Order quantity exceeds available stock.");
            }
        }
        var stocks = _stockService.GetAllStocks();
        ViewBag.StockList = new SelectList(stocks, "Id", "Name");
        return View(order);
    }

    public IActionResult Delete(int id)
    {
        var order = _orderService.GetOrderById(id);
        if (order != null)
        {
            _orderService.DeleteOrder(id);
            _stockService.UpdateStockQuantity(order.StockId, order.OrderQty);
        }
        return RedirectToAction("Index");
    }
}
