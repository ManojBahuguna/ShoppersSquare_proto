using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppersSquare_proto.Models;

namespace ShoppersSquare_proto.Controllers
{
    public class ProductsTempController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: ProductsTemp
        public async Task<ActionResult> Index()
        {
            var products = _context.Products.Include(p => p.ProductType);
            return View(await products.ToListAsync());
        }

        // GET: ProductsTemp/Details/5
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

        // GET: ProductsTemp/Create
        public ActionResult Create()
        {
            ViewBag.ProductTypeId = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: ProductsTemp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,ImageUrl,Price,ProductTypeId,DateAdded,Ratings,Sold,Tags")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Redirect("/");
            }

            ViewBag.ProductTypeId = new SelectList(_context.Categories, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: ProductsTemp/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            return View(product);
        }

        // POST: ProductsTemp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,ImageUrl,Price,ProductTypeId,DateAdded,Ratings,Sold,Tags")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Redirect("~");
            }
            ViewBag.ProductTypeId = new SelectList(_context.Categories, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: ProductsTemp/Delete/5
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

        // POST: ProductsTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
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
