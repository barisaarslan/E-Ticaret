using E_Ticaret.Data;
using E_Ticaret.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.SalesStartDate < System.DateTime.Now.AddYears(-1))
                {
                    ModelState.AddModelError("", "Satışa açıldığı tarih en fazla 1 yıl geriye yönelik olabilir.");
                    return View(model);
                }

                var product = new Product
                {
                    ProductCode = model.ProductCode,
                    ProductName = model.ProductName,
                    Description = model.Description,
                    Price = model.Price,
                    StockQuantity = model.StockQuantity,
                    SalesStartDate = model.SalesStartDate
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Ürün başarıyla eklendi!";
                return RedirectToAction("Create");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult List()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
