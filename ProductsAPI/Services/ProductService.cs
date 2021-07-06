using ProductsAPI.Domain;
using ProductsAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductsAPI.Services
{

    public class ProductService
    {
        private readonly ProductRepository productRepository;
        public ProductService(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        internal IEnumerable<ProductResume> ListProducts(ProductFilter filter)
        {
            var result = productRepository
                .FilterBy(q => 
                (!string.IsNullOrEmpty(filter.Query) && q.Name.Contains(filter.Query))
                &&(!string.IsNullOrEmpty(filter.Category) && q.Category.ToLower().Contains(filter.Category.ToLower()))
                &&(q.Price>filter.MinPrice && q.Price<filter.MaxPrice)
                )
                .Select(p => new ProductResume { Name = p.Name, Price = p.Price});
            return result;
        }

        internal FilterLimits getFilterLimits()
        {
            FilterLimits limits = new FilterLimits();
            limits.Categories = productRepository.AsQueryable().Select(q=> q.Category).Distinct().ToList();
            limits.MaxPrice = productRepository.AsQueryable().Select(q => q.Price).Max();
            limits.MinPrice = productRepository.AsQueryable().Select(q => q.Price).Min();
            return limits;
        }

        internal Product GetProductDetails(string id)
        {
            return productRepository.FindById(id);
        }

        internal void CreateProduct(Product value)
        {
            productRepository.InsertOne(value);
        }

        internal void UpdateProduct(string id, Product value)
        {
            var product = productRepository.FindById(id);
            if(product != null) 
            {
                if(!string.IsNullOrEmpty(value.Name)) product.Name = value.Name;
                if (!string.IsNullOrEmpty(value.Description)) product.Description = value.Description;
                if (!string.IsNullOrEmpty(value.Category)) product.Category = value.Category;
                if (value.Price > 0) product.Price = value.Price;

                productRepository.ReplaceOne(product);
            }
        }

        internal void DeleteProduct(string id)
        {
            var product = productRepository.FindById(id);
            if (product != null) productRepository.DeleteById(id);
        }
    }
}
