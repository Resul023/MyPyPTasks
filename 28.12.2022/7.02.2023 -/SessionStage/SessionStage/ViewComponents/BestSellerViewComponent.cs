using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionStage.DATA;
using SessionStage.Models;

namespace SessionStage.ViewComponents;
public class BestSellerViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public BestSellerViewComponent(AppDbContext context)
    {
        this._context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<Product> products = await _context.Products.ToListAsync();
        return View(products);
    }
}

