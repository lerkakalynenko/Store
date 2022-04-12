using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Entities;
using Store.Models;
using Store.Services.Interfaces;

namespace Store.Controllers
{
    [Route("product")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        [HttpGet]
        public IActionResult Index(FilterViewModel model)
        {

            model.Books =  _bookService.GetAll();
            model.Categories =  _categoryService.GetAll();

            return View(model);
        }
       

        //[HttpPost]
        //public IActionResult Index(FilterViewModel model, int value, int sort)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    if (value == 0)
        //    {
        //        if (sort == 0)
        //        {
        //            model.Books =  _bookService.GetAll();
        //            model.Categories =  _categoryService.GetAll();
        //            return View(model);
        //        }
        //        if (sort == 1)
        //        {
        //            model.Books = _bookService.GetAll();
        //            model.Books = _bookService.RangeByPriceMin();
        //            model.Categories = _categoryService.GetAll();
        //            return View(model);
        //        }

        //        if (sort == 2)
        //        {
        //            model.Books = _bookService.GetAll();
        //            model.Books = _bookService.RangeByPriceMax();
        //            model.Categories = _categoryService.GetAll();
        //            return View(model);
        //        }

        //    }

        //    if (sort == 0)
        //    {
        //        model.Categories = _categoryService.GetAll();
        //        model.Books = _bookService.GetAll().Where(b => b.Category.Id == value);
        //        return View(model);

        //    }

        //    if (sort == 1)
        //    {
        //        model.Categories = _categoryService.GetAll();
        //        model.Books = _bookService.GetAll().Where(b => b.Category.Id == value).OrderBy(
        //            c => c.Price);

        //        return View(model);

        //    }

        //    if (sort == 2)
        //    {
        //        model.Categories = _categoryService.GetAll();
        //        model.Books = _bookService.GetAll().Where(b => b.Category.Id == value).OrderBy(
        //            c => c.Price).Reverse();
        //        return View(model);
        //    }


        //    return RedirectToAction("Index");
        //}

        //private List<Book> CreateDemoProductList()
        //{

        //    return (List<Book>)_bookService.GetAll();

        //}
    }
}
