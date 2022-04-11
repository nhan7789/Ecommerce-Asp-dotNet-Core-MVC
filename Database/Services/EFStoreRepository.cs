using Common.Entites;
using Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Services
{
    public class EFStoreRepository : IStoreRepository
    {
        private DatabaseContext context;
        public EFStoreRepository(DatabaseContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
        public IQueryable<Category> Categories => context.Categories;
        //---------------------------------------- Top products
        public IQueryable<OrderDetail> OrderDetails => context.OrderDetails;
        public IQueryable<Order> Orders => context.Orders;
    }
}
