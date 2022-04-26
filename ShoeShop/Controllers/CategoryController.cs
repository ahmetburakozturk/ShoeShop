﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos;
using ShoeShop.Dtos.Requests;
using ShoeShop.Entities;

namespace ShoeShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Show()
        {
            var categories = _categoryService.GetAllCategories().OrderBy(c=>c.ID).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.AddCategory(categoryDto);
                return RedirectToAction(nameof(Show), nameof(Category));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_categoryService.isExist(id))
            {
                var category = _categoryService.GetCategoryById(id);
                return View(category);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(categoryDto);
                return RedirectToAction(nameof(Show),nameof(Category));
            }

            return View();
        }
    }
}
