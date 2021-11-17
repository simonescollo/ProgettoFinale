using ProgettoIndividuale.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Services
{
    public interface ICategoryServices
    {
        public IEnumerable<Category> GetAll();

        public Category GetById(int? id);

    }
}
