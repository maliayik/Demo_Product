﻿using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public IActionResult Index()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            ProductValidator validationRules = new ProductValidator();
            categoryManager.TInsert(p);
            return RedirectToAction("Index");       

        }

        public IActionResult DeleteCategory(int id)
        {
            var value = categoryManager.TGetById(id);
            categoryManager.TDelete(value);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = categoryManager.TGetById(id);
            return View(value);
        }


        [HttpPost]
        public IActionResult UpdateCategory(Category p)
        {
            categoryManager.TUpdate(p);
            return RedirectToAction("Index");

        }
    }
}
