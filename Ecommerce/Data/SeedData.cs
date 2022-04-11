using Common.Entites;
using Database.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            DatabaseContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        CategoryName = "Adidas",
                    },
                    new Category
                    {
                        CategoryName = "Nike",
                    },
                    new Category
                    {
                        CategoryName = "Puma",
                    }
                );
                context.SaveChanges();

            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        ProductName = "Predator 19 - FG",
                        ProductImage = "predator19fg.jpg",
                        Descriptions = "Predator 19 - FG Full Size",
                        ProductQuantity = 100,
                        ProductPrice = 300,
                        CreateDate = DateTime.Now,
                        CategoryId = 1,
                    },
                    new Product
                    {
                        ProductName = "Predator 203 - TF",
                        ProductImage = "predator203tf.jpg",
                        Descriptions = "Predator 203 - TF Full Size",
                        ProductQuantity = 100,
                        ProductPrice = 300,
                        CreateDate = DateTime.Now,
                        CategoryId = 1,
                    },
                    new Product
                    {
                        ProductName = "X Ghosted 3 Turf Boots Pink - FG",
                        ProductImage = "X_Ghosted_3_Turf_Boots_Pink.jpg",
                        Descriptions = "X Ghosted 3 Turf Boots Pink - FG Full Size",
                        ProductQuantity = 100,
                        ProductPrice = 300,
                        CreateDate = DateTime.Now,
                        CategoryId = 1,
                    },
                                        new Product
                                        {
                                            ProductName = "a",
                                            ProductImage = "a",
                                            Descriptions = "a",
                                            ProductQuantity = 100,
                                            ProductPrice = 300,
                                            CreateDate = DateTime.Now,
                                            CategoryId = 1,
                                        },
                                                            new Product
                                                            {
                                                                ProductName = "b",
                                                                ProductImage = "b",
                                                                Descriptions = "b",
                                                                ProductQuantity = 100,
                                                                ProductPrice = 300,
                                                                CreateDate = DateTime.Now,
                                                                CategoryId = 1,
                                                            },
                                                                                new Product
                                                                                {
                                                                                    ProductName = "c",
                                                                                    ProductImage = "c",
                                                                                    Descriptions = "c",
                                                                                    ProductQuantity = 100,
                                                                                    ProductPrice = 300,
                                                                                    CreateDate = DateTime.Now,
                                                                                    CategoryId = 1,
                                                                                },
                    new Product
                    {
                        ProductName = "Mercurial Fuperfly 7 - FG",
                        ProductImage = "mercurialsuperfly7.jpg",
                        Descriptions = "Mercurial Fuperfly 7 - FG Full Size",
                        ProductQuantity = 100,
                        ProductPrice = 250,
                        CreateDate = DateTime.Now,
                        CategoryId = 2,
                    },
                    new Product
                    {
                        ProductName = "Puma Future 54 - FG",
                        ProductImage = "pumafuture54fg.jpg",
                        Descriptions = "Puma Future 54 - FG Full Size",
                        ProductQuantity = 100,
                        ProductPrice = 200,
                        CreateDate = DateTime.Now,
                        CategoryId = 3,
                    },
                    new Product
                    {
                        ProductName = "Puma King Pro - FG",
                        ProductImage = "pumakingpro.jpg",
                        Descriptions = "Puma King Pro - FG Full Size",
                        ProductQuantity = 100,
                        ProductPrice = 200,
                        CreateDate = DateTime.Now,
                        CategoryId = 3,
                    }
                );
                context.SaveChanges();

            }

        }
    }

}
