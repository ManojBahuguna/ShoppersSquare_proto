using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ShoppersSquare_proto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppersSquare_proto.Controllers
{
    public class ProductsController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Category(String categoryName)
        {
            categoryName = categoryName.Replace('-', ' ');
            var category = _context.Categories.Where(c => c.Name == categoryName);
            if (category.Count() == 0)
                return HttpNotFound();
            return View(category.Single());
        }

        public ActionResult Search(String query)
        {
            var products = DoSearch(query);
            return View(products);
        }
        
        public ActionResult SearchProducts([Bind(Prefix = "id")] String query)
        {
            if (query == null || query.Length == 0)
                return null;

            var searchResults = new List<ProductSearchResult>();
            DoSearch(query).ForEach(p => searchResults.Add(new ProductSearchResult { id = p.Id, name = p.Name }));

            return Json(searchResults, JsonRequestBehavior.AllowGet);
        }

        private List<Product> DoSearch(String query)
        {
            var products = _context.Products
                .Where(
                    p => p.Name.ToLower().Contains(query.ToLower()) ||
                    p.Tags.ToLower().Contains(query.ToLower())
                )
                .OrderByDescending(p => p.Ratings)
                .Take(10).ToList();
            return products;
        }
        
        [Authorize(Roles = "StoreManager")]
        public ActionResult Add(int? category)
        {
            ViewBag.ProductTypeId = new SelectList(_context.Categories, "Id", "Name", category);
            ViewBag.isNew = true;
            return View("Edit");
        }

        [Authorize(Roles = "StoreManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Include = "Name,Description,ImageUrl,Price,ProductTypeId,Tags")] Product product)
        {
            product.DateAdded = DateTime.Now;
            product.Sold = 0;
            product.Ratings = 0;

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Redirect("~");
            }

            ViewBag.ProductTypeId = new SelectList(_context.Categories, "Id", "Name", product.ProductTypeId);
            ViewBag.isNew = true;
            return View("Edit", product);
        }

        [Authorize(Roles = "StoreManager")]
        public async Task<ActionResult> Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeId = new SelectList(_context.Categories, "Id", "Name", product.ProductTypeId);
            ViewBag.isNew = false;
            return View("Edit", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "StoreManager")]
        public async Task<ActionResult> Update([Bind(Include = "Id,Name,Description,ImageUrl,Price,ProductTypeId,DateAdded,Ratings,Sold,Tags")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Redirect("~");
            }
            ViewBag.ProductTypeId = new SelectList(_context.Categories, "Id", "Name", product.ProductTypeId);
            ViewBag.isNew = false;
            return View("Edit", product);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "StoreManager")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Redirect("~");
        }
        
        [HttpPost]
        public ActionResult AddToCart(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { status = "Unauthorized", msg = "Please login first!" });
            }
            if (id == null)
            {
                return Json(new { status = "BadRequest", msg = "No Input Recieved!" });
            }
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return Json(new { status = "NotFound", msg = "Product Not Found!" });
            }
            var currentUser = GetCurrentUser();
            currentUser.Cart.Products.Add(product);
            currentUser.Cart.Date = DateTime.Now;
            currentUser.Cart.Address = currentUser.Address;
            currentUser.Cart.OrderStatusId = _context.OrderStates.First(o => o.Name == "In Process").Id;
            currentUser.Cart.UserId = currentUser.Id;
            _context.SaveChanges();

            return Json(new { status = "Ok", msg = "Product added to cart!"});
        }

        [Authorize]
        public ActionResult Checkout()
        {
            return View(GetCurrentUser());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Checkout")]
        public ActionResult CheckoutConfirmed(Order order)
        {
            return View();
        }


        private ApplicationUser GetCurrentUser()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = _context.Users.First(u => u.Id == currentUserId);
            return currentUser;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}