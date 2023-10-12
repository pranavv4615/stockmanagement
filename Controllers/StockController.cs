using Microsoft.AspNetCore.Mvc;
using StockOrderManagement.Models;
namespace StockOrderManagement.Services;

public class StockController : Controller
{
    private readonly IStockService _stockService;

    public StockController(IStockService stockService)
    {
        _stockService = stockService;
    }

    public IActionResult Index()
    {
        var stocks = _stockService.GetAllStocks();
        return View(stocks);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Stock stock)
    {
        if (ModelState.IsValid)
        {
            _stockService.AddStock(stock);
            return RedirectToAction("Index");
        }
        return View(stock);
    }

    public IActionResult Delete(int id)
    {
        bool stockDeleted = _stockService.DeleteStock(id);

        if (stockDeleted)
        {
            // Stock was deleted successfully
            ViewBag.ShowAlert = "1";
        }
        else
        {
            // Stock couldn't be deleted
            ViewBag.ShowAlert = "0";
        }
        return RedirectToAction("Index");
    }
}
