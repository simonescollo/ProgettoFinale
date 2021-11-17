using ProgettoIndividuale.Domain;
using ProgettoIndividuale.Services.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Services
{
    public interface IProductsServices
    {
        IEnumerable<Product> GetAll();

        IEnumerable<Product> Search(ProductSearchRequest request);

        Product Get(int id);

        Product Update(Product element);

        Product Insert(Product element);

        void Delete(Product element);
    }
}
