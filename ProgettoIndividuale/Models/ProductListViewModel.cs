using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Models
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            this.ProductList = new List<ProductViewModel>();
        }
        /// <summary>
        /// info su lista prodotti
        /// </summary>
        public List<ProductViewModel> ProductList { get; private set; }
        /// <summary>
        /// info sulla impaginazione 
        /// </summary>
        public PaginationViewModel Pagination { get; set; }

    }
}
