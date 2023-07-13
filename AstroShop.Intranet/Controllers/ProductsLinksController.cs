using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AstroShop.Data.Data;
using AstroShop.Data.Data.CMS;

namespace AstroShop.Intranet.Controllers
{
    public class ProductsLinksController : Controller
    {
        private readonly AstroShopContext _context;

        public ProductsLinksController(AstroShopContext context)
        {
            _context = context;
        }

        // GET: Article
        public async Task<IActionResult> Index()
        {
              return _context.ProductsLinks != null ? 
                          View(await _context.ProductsLinks.ToListAsync()) :
                          Problem("Entity set 'AstroShopContext.ProductsLinks'  is null.");
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductsLinks == null)
            {
                return NotFound();
            }

            var links = await _context.ProductsLinks
                .FirstOrDefaultAsync(m => m.IDProductsLinks == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // GET: Article/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDProductsLinks,Title,LinkTitle,DisplayPosition,IsActive")] ProductsLinks links)
        {
            if (ModelState.IsValid)
            {

                links.IsActive = true;
                _context.Add(links);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(links);
        }

        // GET: Article/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductsLinks == null)
            {
                return NotFound();
            }

            var links = await _context.ProductsLinks.FindAsync(id);
            if (links == null)
            {
                return NotFound();
            }
            return View(links);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDProductsLinks,Title,LinkTitle,DisplayPosition,IsActive")] ProductsLinks links)
        {
            if (id != links.IDProductsLinks)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(links);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsLinksExist(links.IDProductsLinks))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(links);
        }

        // GET: Article/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductsLinks == null)
            {
                return NotFound();
            }

            var links = await _context.ProductsLinks
                .FirstOrDefaultAsync(m => m.IDProductsLinks == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductsLinks == null)
            {
                return Problem("Entity set 'AstroShopContext.ProductsLinks'  is null.");
            }
            var links = await _context.ProductsLinks.FindAsync(id);
            if (links != null)
            {
                _context.ProductsLinks.Remove(links);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsLinksExist(int id)
        {
          return (_context.ProductsLinks?.Any(e => e.IDProductsLinks == id)).GetValueOrDefault();
        }
    }
}
