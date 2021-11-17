using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Services.Request
{
    public class ProductSearchRequest
    {
        public string ProductName { get; set; }

        public int? CategoryId { get; set; }
    }
}
