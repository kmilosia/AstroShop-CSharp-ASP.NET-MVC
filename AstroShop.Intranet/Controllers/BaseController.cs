using AstroShop.Data.Data;
using AstroShop.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroShop.Intranet.Controllers
{
    public abstract class BaseController<BaseEntity> : Controller
    {
        protected readonly AstroShopContext _context;
        public BaseController(AstroShopContext context)
        {
            _context = context;
        }
        public abstract Task<List<BaseEntity>> GetEntityList();
        public async Task<IActionResult> Index()
        {
            return View(await GetEntityList());
        }
        public virtual Task SetSelectList()
        {
            return null;
        }
        public async Task<IActionResult> Create()
        {
            await SetSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BaseEntity entity)
        {
            //entity.IsActive = true;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }   


    }
}
