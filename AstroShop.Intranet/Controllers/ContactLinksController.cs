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
    public class ContactLinksController : Controller
    {
        private readonly AstroShopContext _context;

        public ContactLinksController(AstroShopContext context)
        {
            _context = context;
        }

        // GET: Article
        public async Task<IActionResult> Index()
        {
              return _context.ContactLinks != null ? 
                          View(await _context.ContactLinks.ToListAsync()) :
                          Problem("Entity set 'AstroShopContext.ContactLinks'  is null.");
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactLinks == null)
            {
                return NotFound();
            }

            var article = await _context.ContactLinks
                .FirstOrDefaultAsync(m => m.IDContactLinks == id);
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
        public async Task<IActionResult> Create([Bind("IDContactLinks,Title,URLAdress,Icon,Content,DisplayPosition,IsActive")] ContactLinks article)
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
            if (id == null || _context.ContactLinks == null)
            {
                return NotFound();
            }

            var article = await _context.ContactLinks.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("IDContactLinks,Title,URLAdress,Icon,Content,DisplayPosition,IsActive")] ContactLinks article)
        {
            if (id != article.IDContactLinks)
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
                    if (!ArticleExists(article.IDContactLinks))
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
            if (id == null || _context.ContactLinks == null)
            {
                return NotFound();
            }

            var article = await _context.ContactLinks
                .FirstOrDefaultAsync(m => m.IDContactLinks == id);
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
            if (_context.ContactLinks == null)
            {
                return Problem("Entity set 'AstroShopContext.ContactLinks'  is null.");
            }
            var article = await _context.ContactLinks.FindAsync(id);
            if (article != null)
            {
                _context.ContactLinks.Remove(article);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
          return (_context.ContactLinks?.Any(e => e.IDContactLinks == id)).GetValueOrDefault();
        }
    }
}
