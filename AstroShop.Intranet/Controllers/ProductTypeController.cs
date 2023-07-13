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
    public class ProductTypeController : Controller
    {
        private readonly AstroShopContext _context;

        public ProductTypeController(AstroShopContext context)
        {
            _context = context;
        }

        // GET: Article
        public async Task<IActionResult> Index()
        {
              return _context.Type != null ? 
                          View(await _context.Type.ToListAsync()) :
                          Problem("Entity set 'AstroShopContext.Type'  is null.");
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Type == null)
            {
                return NotFound();
            }

            var article = await _context.Type
                .FirstOrDefaultAsync(m => m.IDType == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
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
        public async Task<IActionResult> Create([Bind("IDType,Name,Description,IsActive")] AstroShop.Data.Data.Shop.Type article)
        {
            if (ModelState.IsValid)
            {
                article.IsActive = true;
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Article/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Type == null)
            {
                return NotFound();
            }

            var article = await _context.Type.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDType,Name,Description,IsActive")] AstroShop.Data.Data.Shop.Type article)
        {
            if (id != article.IDType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.IDType))
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
            return View(article);
        }

        // GET: Article/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Type == null)
            {
                return NotFound();
            }

            var article = await _context.Type
                .FirstOrDefaultAsync(m => m.IDType == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Type == null)
            {
                return Problem("Entity set 'AstroShopContext.Type'  is null.");
            }
            var article = await _context.Type.FindAsync(id);
            if (article != null)
            {
                _context.Type.Remove(article);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
          return (_context.Type?.Any(e => e.IDType == id)).GetValueOrDefault();
        }
    }
}
