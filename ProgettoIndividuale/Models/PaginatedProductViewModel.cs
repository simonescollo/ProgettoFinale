using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Models
{
    public class PaginationViewModel
    {
        /// <summary>
        ///  pagina attuale
        /// </summary>
        public int ActualPage { get; set; }
        /// <summary>
        /// ultima pagina
        /// </summary>
        public int MaxPage { get; set; }
        /// <summary>
        /// numero di elementi per pagina
        /// </summary>
        public int PerPage { get; set; }

        public PaginationViewModel(int actualPage, int maxPage, int perPage)
        {
            ActualPage = actualPage;
            MaxPage = maxPage;
            PerPage = perPage;
        }
    }
}
