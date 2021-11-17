using ProgettoIndividuale.Domain;
using ProgettoIndividuale.EF.Models;
using ProgettoIndividuale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Utils
{
    public static class Projections
    {
        internal static IEnumerable<Product> ProjectToDomain(this IQueryable<Products> query)
        {
            return query.Select(x => new Product()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                Discontinued = x.Discontinued,
                QuantityPerUnit = x.QuantityPerUnit,
            });
        }

        internal static Product ProjectToDomain(this Products prodotto)
        {
            return new Product()
            {
                ProductId = prodotto.ProductId,
                ProductName = prodotto.ProductName,
                CategoryId = prodotto.CategoryId,
                UnitPrice = prodotto.UnitPrice,
                UnitsInStock = prodotto.UnitsInStock,
                Discontinued = prodotto.Discontinued,
                QuantityPerUnit = prodotto.QuantityPerUnit,
            };
        }

        internal static IEnumerable<Products> ProjectToDbModel(this IEnumerable<Product> query)
        {
            return query.Select(x => new Products()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                Discontinued = x.Discontinued,
                QuantityPerUnit = x.QuantityPerUnit,
            });
        }

        internal static Products ProjectToDbModel(this Product prodotto)
        {
            return new Products()
            {
                ProductId = prodotto.ProductId,
                ProductName = prodotto.ProductName,
                CategoryId = prodotto.CategoryId,
                UnitPrice = prodotto.UnitPrice,
                UnitsInStock = prodotto.UnitsInStock,
                Discontinued = prodotto.Discontinued,
                QuantityPerUnit = prodotto.QuantityPerUnit,
            };
        }

        internal static IEnumerable<ProductViewModel> ProjectToViewModel(this IEnumerable<Product> query)
        {
            return query.Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                Discontinued = x.Discontinued,
                QuantityPerUnit = x.QuantityPerUnit,
            });
        }

        internal static ProductViewModel ProjectToViewModel(this Product prodotto)
        {
            return new ProductViewModel()
            {
                ProductId = prodotto.ProductId,
                ProductName = prodotto.ProductName,
                CategoryId = prodotto.CategoryId,
                UnitPrice = prodotto.UnitPrice,
                UnitsInStock = prodotto.UnitsInStock,
                Discontinued = prodotto.Discontinued,
                QuantityPerUnit = prodotto.QuantityPerUnit,
            };
        }

        internal static Product ProjectFromViewModel(this ProductViewModel prodotto)
        {
            return new Product()
            {
                ProductId = prodotto.ProductId,
                ProductName = prodotto.ProductName,
                CategoryId = prodotto.CategoryId,
                UnitPrice = prodotto.UnitPrice,
                UnitsInStock = prodotto.UnitsInStock,
                Discontinued = prodotto.Discontinued,
                QuantityPerUnit = prodotto.QuantityPerUnit,
            };
        }

        internal static IEnumerable<Category> ProjectToDomainCategory(this IQueryable<Categories> query)
        {
            return query.Select(x => new Category()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
            });
        }

        internal static Category ProjectToDomainCategory(this Categories categoria)
        {
            return new Category()
            {
                CategoryId = categoria.CategoryId,
                CategoryName = categoria.CategoryName,
                Description = categoria.Description,
            };
        }
    }
}
