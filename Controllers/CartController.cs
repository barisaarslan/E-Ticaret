using E_Ticaret.Data;
using E_Ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            if (product.StockQuantity < 1)
            {
                TempData["ErrorMessage"] = "Ürün ekleyemezsiniz. Stok miktarı yetersiz.";
                return RedirectToAction("List", "Product");
            }

            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem { ProductId = productId, Product = product, Quantity = 1 });
            }

            product.StockQuantity--; // Stok miktarını azaltma
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            SaveCart(cart);

            return RedirectToAction("List", "Product");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (cartItem != null)
            {
                cart.Items.Remove(cartItem);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(string firstName, string lastName, string phone, string address)
        {
            var cart = GetCart();
            if (!cart.Items.Any())
            {
                TempData["ErrorMessage"] = "Sepetiniz boş.";
                return RedirectToAction("Index");
            }

            var order = new Order
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Address = address
            };

            foreach (var item in cart.Items)
            {
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                };
                order.OrderItems.Add(orderItem);
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Sipariş numarasını saklayın ve sepeti temizleyin
            TempData["OrderNumber"] = order.OrderId;
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("OrderConfirmation");
        }

        public IActionResult OrderConfirmation()
        {
            var orderNumber = TempData["OrderNumber"];
            if (orderNumber == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.OrderNumber = orderNumber;
            return View();
        }

        private Cart GetCart()
        {
            var cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.Set("Cart", cart);
        }
    }
}
