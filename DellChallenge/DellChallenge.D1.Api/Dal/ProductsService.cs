using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;
using Microsoft.EntityFrameworkCore;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Get(string id)
        {
            return MapToDto(_context.Products.Find(id));
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public void Delete(string id)
        {
            _context.Products.Remove(_context.Products.Find(id));
            _context.SaveChanges();
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }

        public ProductDto Update(string id, NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            product.Id = id;

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return MapToDto(product);
        }
    }
}
