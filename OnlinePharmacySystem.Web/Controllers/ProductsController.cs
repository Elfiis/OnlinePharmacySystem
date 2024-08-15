using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlinePharmacySystem.Web.Models;
using System;
using System.Threading.Tasks;

namespace onlinePharmacySystem.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductPharmacies)
                .Include(p => p.ProductSupplier)
                .ToListAsync();
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductPharmacies)
                .Include(p => p.ProductSupplier)
                .FirstOrDefaultAsync(m => m.ProductID == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}