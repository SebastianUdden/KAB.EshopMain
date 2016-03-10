﻿using EshopMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class ProductDataManager
    {
        ProductContext Context;

        public ProductDataManager(ProductContext context)
        {
            this.Context = context;
        }
        public void AddProduct(CreateProductViewModel viewModel)
        {
            Product p = new Product();
            p.ProductName = viewModel.ProductName;
            p.Price = viewModel.Price;
            p.PictureLink = viewModel.ImageURL;
            p.ProductDescription = viewModel.ProductDescription;
            p.Stock = viewModel.AmountToAdd;
            p.CategoryId = viewModel.Category;

            Context.Products.Add(p);
            Context.SaveChanges();

        }

        public Product GetProductById(int id)
        {
            //this needs testing, *should* return a product object from the database
            var Product = Context.Products.Select(x => new Product
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                Price = x.Price,
                PictureLink = x.PictureLink,
                Stock = x.Stock,
                CategoryId = x.CategoryId,
            }).Where(x => x.Id == id).ToArray();
            return Product[0];

        }

        public ProductListViewModel[] GetProductByCategory(int categoryId)
        {
            //untested
            var Product = Context.Products.Select(x => new ProductListViewModel
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                Price = x.Price,
                ImageURL = x.PictureLink,
                Stock = x.Stock,
                CategoryId = x.CategoryId
            }).Where(x => x.CategoryId == categoryId).ToArray();
            return Product;
        }
    }
}
