using Database.Services;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Entites;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 3;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            var queryTopProducts = (from p in repository.Products
                                    let totalQuantity = (from op in repository.OrderDetails
                                                         join o in repository.Orders on op.OrderId equals o.OrderId
                                                         where op.ProductId == p.ProductId && o.OrderDate <= DateTime.Now
                                                         select op.Quantity).Sum()
                                    where totalQuantity > 0
                                    orderby totalQuantity descending
                                    select p).Take(4);
            ViewBag.TopProducts = queryTopProducts;
            return View();
        }
        public IActionResult Category(string category, int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                Products = repository.Products
                            .Where(p => category == null || p.Category.CategoryName == category)
                            .OrderBy(p => p.ProductId)
                            .Skip((productPage - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category.CategoryName == category).Count()
                },
                CurrentCategory = category
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
