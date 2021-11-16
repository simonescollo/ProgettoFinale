using Microsoft.AspNetCore.Mvc;
using ProgettoIndividuale.Domain;
using ProgettoIndividuale.EF.Data;
using ProgettoIndividuale.Models;
using ProgettoIndividuale.Services;
using ProgettoIndividuale.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoIndividuale.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsServices _service;
        public ProductController(IProductsServices service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll().ProjectToViewModel().ToList());
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
                    _service.Update(_service.Get(id));
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
