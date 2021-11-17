using Microsoft.AspNetCore.Mvc;
using ProgettoIndividuale.Domain;
using ProgettoIndividuale.Models;
using ProgettoIndividuale.Services;
using ProgettoIndividuale.Utils;
using System.Linq;

namespace ProgettoIndividuale.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsServices _service;
        public ProductController(IProductsServices service)
        {
            _service = service;
        }
        public IActionResult Index(int page, int perPage)
        {
            var paginatedQuery = _service.GetAll().ProjectToViewModel().ToPaginated(pageIndex: page, pageSize: perPage);

            var products = paginatedQuery.ToList();

            ProductListViewModel model = new ProductListViewModel()
            {
                Pagination = new PaginationViewModel(actualPage: paginatedQuery.PageIndex, maxPage: paginatedQuery.TotalPages - 1, perPage: paginatedQuery.PageSize)
            };

            foreach (var prodotto in products)
            {
                model.ProductList.Add(prodotto);
            }
            return View(model);
        }

        public IActionResult Delete(int id) 
        {
            _service.Delete(_service.Get(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Save(int id)
        {
            Product elemento;

            if (id != 0)
            {
                elemento = _service.Get(id);
            }
            else
            {
                elemento = new();
                elemento.ProductId = id;
            }
            return View("Save", elemento.ProjectToViewModel());
        }
        [HttpPost]
        public IActionResult Save(ProductViewModel elemento)
        {
            int id = elemento.ProductId;
            if (ModelState.IsValid)
            {
                if (elemento.ProductId != 0)
                {
                    _service.Update(elemento.ProjectFromViewModel());
                }
                else
                {
                    elemento.ProductId = _service.GetAll().ToList().Count() + 1;
                    _service.Insert(elemento.ProjectFromViewModel());
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Save", elemento);
            }
        }
    }
}
