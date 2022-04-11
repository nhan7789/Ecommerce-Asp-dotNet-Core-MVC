using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Common.Entites
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        [DisplayName("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [DisplayName("Products")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Price Amount")]
        public double PriceAmount { get; set; }

    }
}
