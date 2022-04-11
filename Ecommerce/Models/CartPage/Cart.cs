using Common.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.CartPage
{
    public class Cart
    {
        public List<OrderDetail> Lines { get; set; } = new List<OrderDetail>();
        public virtual void AddItem(Product product, int quantity)
        {
            OrderDetail line = Lines
            .Where(p => p.Product.ProductId == product.ProductId)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new OrderDetail
                {
                    Product = product,
                    Quantity = quantity,

                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);
        public double ComputeTotalValue() => Lines.Sum(e => e.Product.ProductPrice * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
}
