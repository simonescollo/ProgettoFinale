using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Utils
{
    public static class PaginatedEnumerableExtensions
    {
        /// <summary>
        /// Crea un enumerable che sia paginabile
        /// </summary>
        /// <param name="enumerable">enumerable da paginare</param>
        /// <param name="pageIndex">indice di pagina corrente (per es. 2 di 5)</param>
        /// <param name="pageSize">grandezza della pagina (per es. una pagina contiene 10 elementi)</param>
        /// <param name="totalCount">numeri di elementi da processare (per es. 50 elementi)</param>
        public static PaginatedEnumerable<T> ToPaginated<T>(this IEnumerable<T> enumerable, int? totalCount = null, int pageIndex = 0, int pageSize = 10)
        {
            return new PaginatedEnumerable<T>(enumerable, totalCount, pageIndex, pageSize);
        }

        public static IEnumerable<T> ToList<T>(this PaginatedEnumerable<T> source)
        {
            return source.Skip((source.PageIndex) * source.PageSize)
                         .Take(source.PageSize)
                         .ToList();
        }
    }

    /// <summary>
    /// Consente di paginare una collezione
    /// </summary>
    public class PaginatedEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _enumerable;

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public int TotalPages { get; private set; }

        /// <summary>
        /// Da quale elemento si inizia a iterare (es. 21)
        /// </summary>
        public int ItemsStartCount { get { return this.PageIndex * this.PageSize + 1; } }

        /// <summary>
        /// Da quale elemento si finisce di iterare (es. 21)
        /// </summary>
        public int ItemsEndCount { get { return Math.Min((this.PageIndex + 1) * this.PageSize, this.TotalCount); } }

        public bool HasPreviousPage { get { return (PageIndex > 0); } }

        public bool HasNextPage { get { return (PageIndex + 1 < TotalPages); } }

        /// <summary>
        /// Crea una collezione vuota
        /// </summary>
        public static PaginatedEnumerable<T> Empty()
        {
            return new PaginatedEnumerable<T>();
        }



        /// <summary>
        /// Crea un enumerable che sia paginabile
        /// </summary>
        /// <param name="enumerable">enumerable da paginare</param>
        /// <param name="pageIndex">indice di pagina corrente (per es. 2 di 5)</param>
        /// <param name="pageSize">grandezza della pagina (per es. una pagina contiene 10 elementi)</param>
        /// <param name="totalCount">numeri di elementi da processare (per es. 50 elementi)</param>
        public PaginatedEnumerable(IEnumerable<T> enumerable = null, int? totalCount = null, int pageIndex = 0, int pageSize = 10)
        {
            if (enumerable == null)
                enumerable = Enumerable.Empty<T>();
            _enumerable = enumerable;
            this.PageIndex = pageIndex < 0 ? 0 : pageIndex;
            this.PageSize = pageSize <= 0 ? 10 : pageSize;
            this.TotalCount = totalCount ?? enumerable.Count();
            this.TotalPages = (TotalCount / PageSize) + (TotalCount % PageSize == 0 ? 0 : 1);
            this.PageIndex = pageIndex >= TotalPages ? TotalPages - 1 : pageIndex;
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _enumerable.GetEnumerator();
        }

        /// <summary>
        /// Copia le stesse info di paginazione in una collezione con un tipo diverso.
        /// Utile quando si converte da una collezione a un'altra collezione e si vogliono
        /// mantenere le info di paginazione
        /// </summary>
        public PaginatedEnumerable<TDestination> Clone<TDestination>(IEnumerable<TDestination> enumerableDestination)
        {
            return new PaginatedEnumerable<TDestination>(enumerableDestination, this.TotalCount, this.PageIndex, this.PageSize);
        }
    }
}