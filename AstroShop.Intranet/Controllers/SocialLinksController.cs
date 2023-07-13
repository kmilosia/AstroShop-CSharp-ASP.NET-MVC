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
    public class SocialLinksController : Controller
    {
        private readonly AstroShopContext _context;

        public SocialLinksController(AstroShopContext context)
        {
            _context = context;
        }

        // GET: SocialLinks
        public async Task<IActionResult> Index()
        {
              return _context.SocialLinks != null ? 
                          View(await _context.SocialLinks.ToListAsync()) :
                          Problem("Entity set 'AstroShopContext.SocialLinks'  is null.");
        }

        // GET: SocialLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SocialLinks == null)
            {
                return NotFound();
            }

            var sociallinks = await _context.SocialLinks
                .FirstOrDefaultAsync(m => m.IDSocialLinks == id);
            if (sociallinks == null)
            {
                return NotFound();
            }

            return View(sociallinks);
        }

        // GET: SocialLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDSocialLinks,Title,URLAdress,Icon,DisplayPosition,IsActive")] SocialLinks sociallinks)
        {
            if (ModelState.IsValid)
            {
                sociallinks.IsActive = true;
                _context.Add(sociallinks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sociallinks);
        }

        // GET: SocialLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SocialLinks == null)
            {
                return NotFound();
            }

            var sociallinks = await _context.SocialLinks.FindAsync(id);
            if (sociallinks == null)
            {
                return NotFound();
            }
            return View(sociallinks);
        }

        // POST: SocialLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDSocialLinks,Title,URLAdress,Icon,DisplayPosition,IsActive")] SocialLinks sociallinks)
        {
            if (id != sociallinks.IDSocialLinks)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sociallinks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialLinksexists(sociallinks.IDSocialLinks))
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
            return View(sociallinks);
        }

        // GET: Article/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SocialLinks == null)
            {
                return NotFound();
            }

            var sociallinks = await _context.SocialLinks
                .FirstOrDefaultAsync(m => m.IDSocialLinks == id);
            if (sociallinks == null)
            {
                return NotFound();
            }

            return View(sociallinks);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SocialLinks == null)
            {
                return Problem("Entity set 'AstroShopContext.SocialLinks'  is null.");
            }
            var sociallinks = await _context.SocialLinks.FindAsync(id);
            if (sociallinks != null)
            {
                _context.SocialLinks.Remove(sociallinks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialLinksexists(int id)
        {
          return (_context.SocialLinks?.Any(e => e.IDSocialLinks == id)).GetValueOrDefault();
        }
    }
}
