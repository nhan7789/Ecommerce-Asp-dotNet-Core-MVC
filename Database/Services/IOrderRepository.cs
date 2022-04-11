using Common.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Services
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
