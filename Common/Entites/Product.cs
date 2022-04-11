using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entites
{
    public class Product
    {
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Please fill the Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Product Quantity")]
        [Required(ErrorMessage = "Please fill the Product Quantity")]
        [Range(1, 500, ErrorMessage = "Quantity is only about 1-500")]
        public int ProductQuantity { get; set; }
        [Required]
        [Range(10, 1000, ErrorMessage = "Prices is only about 10 - 1000 ")]
        [DisplayName("Product Price")]
        public double ProductPrice { get; set; }
        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Descriptions")]
        public string Descriptions { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Image")]
        public string ProductImage { get; set; }

    }
}
