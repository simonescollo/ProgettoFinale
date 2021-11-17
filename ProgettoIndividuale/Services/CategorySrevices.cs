using ProgettoIndividuale.Domain;
using ProgettoIndividuale.EF.Data;
using ProgettoIndividuale.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Services
{
    public class CategorySrevices : ICategoryServices
    {
        private NORTHWINDContext _context;

        public CategorySrevices(NORTHWINDContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.AsQueryable().ProjectToDomainCategory();
        }

        public Category GetById(int? id)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId == id).ProjectToDomainCategory();
        }
    }
}
