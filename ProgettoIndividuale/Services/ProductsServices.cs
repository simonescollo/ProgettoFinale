using ProgettoIndividuale.Domain;
using ProgettoIndividuale.EF.Data;
using ProgettoIndividuale.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Services
{
    public class ProductsServices : IProductsServices
    {
        private NORTHWINDContext _context;

        public ProductsServices(NORTHWINDContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.AsQueryable().ProjectToDomain();
        }

        public Product Get(int id) 
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == id).ProjectToDomain();
        }
        public void Delete(Product element)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(x => x.ProductId == element.ProductId));
            _context.SaveChanges();
        }

        public Product Insert(Product element)
        {
            element.ProductId = 0;
            _context.Products.Add(element.ProjectToDbModel());
            _context.SaveChanges();
            int id = _context.Products.ToList().Count();
            element.ProductId = id;
            return element;
        }

        public Product Update(Product element)
        {
            _context.Products.Attach(_context.Products.FirstOrDefault(x => x.ProductId == element.ProductId));
            _context.Products.FirstOrDefault(x => x.ProductId == element.ProductId).ProductName = element.ProductName;
            _context.Products.FirstOrDefault(x => x.ProductId == element.ProductId).CategoryId = element.CategoryId;
            _context.Products.FirstOrDefault(x => x.ProductId == element.ProductId).Discontinued = element.Discontinued;
            _context.Products.FirstOrDefault(x => x.ProductId == element.ProductId).QuantityPerUnit = element.QuantityPerUnit;
            _context.Products.FirstOrDefault(x => x.ProductId == element.ProductId).UnitPrice = element.UnitPrice;
            _context.Products.FirstOrDefault(x => x.ProductId == element.ProductId).UnitsInStock = element.UnitsInStock;
            _context.Products.Update(_context.Products.FirstOrDefault(x => x.ProductId == element.ProductId));
            _context.SaveChanges();
            return element;
        }
    }
}
