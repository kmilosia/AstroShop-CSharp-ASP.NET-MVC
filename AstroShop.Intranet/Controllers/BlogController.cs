using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AstroShop.Data.Data;
using AstroShop.Data.Data.CMS;
using AstroShop.Data.Data.Shop;

namespace AstroShop.Intranet.Controllers
{
    public class BlogController : BaseController<Blog>
    {
        public BlogController(AstroShopContext context)
            : base(context)
        {
        }
        public override async Task<List<Blog>> GetEntityList()
        {
            return await _context.Blog.Include(t => t.BlogType).ToListAsync();
        }
        public override async Task SetSelectList()
        {
            var types = await _context.BlogType.ToListAsync();
            ViewBag.Types = new SelectList(types, "IDBlogType", "Name");
        }
       

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var article = await _context.Blog
                .FirstOrDefaultAsync(m => m.IDBlog == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Article/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await SetSelectList();
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var article = await _context.Blog.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("IDBlog,LinkTitle,Title,Heading,Content,ImageURL,Author,Category,CreationDate,IDBlogType,IsActive")] Blog article)
        {
            if (id != article.IDBlog)
            {
                return NotFound();
            }
           
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.IDBlog))
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

        // GET: Article/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var article = await _context.Blog
                .FirstOrDefaultAsync(m => m.IDBlog == id);
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
            if (_context.Blog == null)
            {
                return Problem("Entity set 'AstroShopContext.Blog'  is null.");
            }
            var article = await _context.Blog.FindAsync(id);
            if (article != null)
            {
                _context.Blog.Remove(article);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
          return (_context.Blog?.Any(e => e.IDBlog == id)).GetValueOrDefault();
        }
    }
}
