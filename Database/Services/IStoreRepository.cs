using Common.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Services
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Category> Categories { get; }
        //---------------------------------------- Top products
        IQueryable<OrderDetail> OrderDetails { get; }
        IQueryable<Order> Orders { get; }

    }
}
