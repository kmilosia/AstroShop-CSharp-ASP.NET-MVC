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
    public class BlogTypeController : Controller
    {
        private readonly AstroShopContext _context;

        public BlogTypeController(AstroShopContext context)
        {
            _context = context;
        }

        // GET: BlogType
        public async Task<IActionResult> Index()
        {
              return _context.BlogType != null ? 
                          View(await _context.BlogType.ToListAsync()) :
                          Problem("Entity set 'AstroShopContext.BlogType'  is null.");
        }

        // GET: BlogType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BlogType == null)
            {
                return NotFound();
            }

            var article = await _context.BlogType
                .FirstOrDefaultAsync(m => m.IDBlogType == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: BlogType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDBlogType,Name,Description,IsActive")] BlogType article)
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

        // GET: BlogType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BlogType == null)
            {
                return NotFound();
            }

            var article = await _context.BlogType.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: BlogType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDBlogType,Name,Description,IsActive")] BlogType article)
        {
            if (id != article.IDBlogType)
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
                    if (!ArticleExists(article.IDBlogType))
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

        // GET: BlogType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BlogType == null)
            {
                return NotFound();
            }

            var article = await _context.BlogType
                .FirstOrDefaultAsync(m => m.IDBlogType == id);
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
            if (_context.BlogType == null)
            {
                return Problem("Entity set 'AstroShopContext.BlogType'  is null.");
            }
            var article = await _context.BlogType.FindAsync(id);
            if (article != null)
            {
                _context.BlogType.Remove(article);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
          return (_context.BlogType?.Any(e => e.IDBlogType == id)).GetValueOrDefault();
        }
    }
}
