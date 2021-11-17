using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.ViewUtils
{
    public class HtmlPaginationHelper
    {
        /// <summary>
        /// Returns an array with element of each position of the pagination, where -1 means "...".
        /// </summary>
        /// <param name="actualPage">The actual (active) page.</param>
        /// <param name="maxPage">The number representing the last page number (= number of pages - 1).</param>
        /// <param name="ends">How many elements to always show after Previous button (and before Next button).</param>
        /// <param name="neighbours">How many elements to always show previous and after the actual (active) page.</param>
        /// <returns></returns>
        public static List<int> PaginationArray(int actualPage, int maxPage, int ends = 3, int neighbours = 2)
        {
            if (maxPage < ends * 2 + neighbours * 2 + 3)
            {
                #region Configuration 1 : [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                return Enumerable.Range(0, maxPage + 1).ToList();
                #endregion
            }
            else if (actualPage + neighbours <= ends + neighbours * 2 + 1)
            {
                #region Configuration 2 : [0, 1, 2, 3, 4, 5, 6, 7, 8, -1, 40, 41, 42]
                List<int> list1 = Enumerable.Range(0, ends + neighbours * 2 + 2).ToList();
                list1.Add(-1);
                List<int> list2 = Enumerable.Range(maxPage - ends + 1, ends).ToList();
                return list1.Concat(list2).ToList();
                #endregion
            }
            else if (actualPage - neighbours >= maxPage - (ends + neighbours * 2 + 1))
            {
                #region Configuration 3 : [0, 1, 2, -1, 34, 35, 36, 37, 38, 39, 40, 41, 42]
                List<int> list1 = Enumerable.Range(0, ends).ToList();
                list1.Add(-1);
                List<int> list2 = Enumerable.Range(maxPage - (ends + neighbours * 2 + 1), ends + neighbours * 2 + 2).ToList();
                return list1.Concat(list2).ToList();
                #endregion
            }
            else
            {
                #region Configuration 4 : [0, 1, 2, -1 18, 19, 20, 21, 22, -1 40, 41, 42]
                List<int> list1 = Enumerable.Range(0, ends).ToList();
                list1.Add(actualPage - neighbours == ends + 1 ? ends + 1 : -1);
                List<int> list2 = Enumerable.Range(actualPage - neighbours, 2 * neighbours + 1).ToList();
                list2.Add(actualPage + neighbours == maxPage - 1 ? maxPage - 1 : -1);
                List<int> list3 = Enumerable.Range(maxPage - ends + 1, ends).ToList();
                return list1.Concat(list2).Concat(list3).ToList();
                #endregion
            }
        }

    }
}
