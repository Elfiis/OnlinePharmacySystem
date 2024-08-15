using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlinePharmacySystem.Web.Models;
using System;
using System.Threading.Tasks;

namespace onlinePharmacySystem.Web.Controllers
{
    public class PharmaciesController : Controller
    {
        private readonly AppDbContext _context;

        public PharmaciesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pharmacies
        public async Task<IActionResult> Index()
        {
            // Veritabanından eczane bilgilerini çek
            var pharmacies = await _context.Pharmacies.ToListAsync();
            return View(pharmacies);
        }

        // GET: Pharmacies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Belirtilen ID'ye sahip eczaneyi ve ürünlerini veritabanından al
            var pharmacy = await _context.Pharmacies
                                         .Include(p => p.PharmacyProducts)
                                         .ThenInclude(pp => pp.ProductBrand)
                                         .FirstOrDefaultAsync(p => p.PharmacyID == id);

            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }
    }
}