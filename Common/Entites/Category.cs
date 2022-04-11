using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entites
{
    public class Category
    {
        public int CategoryId { get; set; }
        [DisplayName("Category products")]
        [Required(ErrorMessage = "Please fill the Category")]
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
