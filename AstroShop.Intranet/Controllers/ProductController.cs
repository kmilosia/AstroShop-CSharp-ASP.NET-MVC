using AstroShop.Data.Data;
using AstroShop.Data.Data.CMS;
using AstroShop.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AstroShop.Intranet.Controllers
{
    public class ProductController : BaseController<Product>
    {
        public ProductController(AstroShopContext context)
            :base(context)
        {
        }
        public override async Task<List<Product>> GetEntityList()
        {
            return await _context.Product.Include(t => t.Type).ToListAsync();       
        }
        public override async Task SetSelectList()
        {
            var types = await _context.Type.ToListAsync();
            ViewBag.Types = new SelectList(types, "IDType", "Name");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.IDProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            await SetSelectList();
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDProduct,Code,Name,Price,ImageURL,Header,Specifications,Description,AddingDate,IDType,IsActive")] Product product)
        {
            if (id != product.IDProduct)
            {
                return NotFound();
            }
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(product.IDProduct))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");       
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.IDProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'AstroShopContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return (_context.Product?.Any(e => e.IDProduct == id)).GetValueOrDefault();
        }
    }
}
