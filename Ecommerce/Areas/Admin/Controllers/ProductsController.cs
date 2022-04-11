using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Common.Entites;
using Database.Contexts;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;
        private SignInManager<Users> _signInManager;


        public ProductsController(SignInManager<Users> signInMgr, DatabaseContext context)
        {
            _context = context;
            _signInManager = signInMgr;

        }

        public async Task<IActionResult> Index()
        {
            //---------------------- Access modifiers  
            if (!_signInManager.IsSignedIn(User))
                return RedirectToPage("/Account/Login",
                new { Area = "Identity" });

            var databaseContext = _context.Products.Include(p => p.Category);
            return View(await databaseContext.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductQuantity,ProductImage,ProductPrice,CreateDate,Descriptions,CategoryId")] Product product, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                if (photo == null || photo.Length == 0)
                {
                    product.ProductImage = "placeholder.jpg";
                }
                else
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/picture", photo.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    photo.CopyTo(stream);
                    product.ProductImage = photo.FileName;
                }

                product.CreateDate = DateTime.Now;

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            TempData["imgPath"] = product.ProductImage;
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return PartialView("_EditModelPartial", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductQuantity,ProductImage,ProductPrice,CreateDate,Descriptions,CategoryId")] Product product, IFormFile photo)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (photo == null || photo.Length == 0)
                    {
                        product.ProductImage = TempData["imgPath"].ToString();
                    }
                    else
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        photo.CopyTo(stream);
                        product.ProductImage = photo.FileName;
                    }

                    product.CreateDate = DateTime.Now;

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteModelPartial", product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
