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
    public class FooterLinksController : Controller
    {
        private readonly AstroShopContext _context;

        public FooterLinksController(AstroShopContext context)
        {
            _context = context;
        }

        // GET: Article
        public async Task<IActionResult> Index()
        {
              return _context.FooterLinks != null ? 
                          View(await _context.FooterLinks.ToListAsync()) :
                          Problem("Entity set 'AstroShopContext.FooterLinks'  is null.");
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FooterLinks == null)
            {
                return NotFound();
            }

            var article = await _context.FooterLinks
                .FirstOrDefaultAsync(m => m.IDFooterLinks == id);
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
        public async Task<IActionResult> Create([Bind("IDFooterLinks,Title,LinkTitle,DisplayPosition,IsActive")] FooterLinks article)
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
            if (id == null || _context.FooterLinks == null)
            {
                return NotFound();
            }

            var article = await _context.FooterLinks.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("IDFooterLinks,Title,LinkTitle,DisplayPosition,IsActive")] FooterLinks article)
        {
            if (id != article.IDFooterLinks)
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
                    if (!ArticleExists(article.IDFooterLinks))
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
            if (id == null || _context.FooterLinks == null)
            {
                return NotFound();
            }

            var article = await _context.FooterLinks
                .FirstOrDefaultAsync(m => m.IDFooterLinks == id);
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
            if (_context.FooterLinks == null)
            {
                return Problem("Entity set 'AstroShopContext.FooterLinks'  is null.");
            }
            var article = await _context.FooterLinks.FindAsync(id);
            if (article != null)
            {
                _context.FooterLinks.Remove(article);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
          return (_context.FooterLinks?.Any(e => e.IDFooterLinks == id)).GetValueOrDefault();
        }
    }
}
