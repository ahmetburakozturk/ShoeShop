﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos.Requests;

namespace ShoeShopWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IGenderService _genderService;

        public ProductsController(IProductService productService,ICategoryService categoryService,
            IBrandService brandService, IColorService colorService, IGenderService genderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _colorService = colorService;
            _genderService = genderService;
        }
        public IActionResult Show(int page)
        {
            var products = _productService.GetAllProducts();
            var productsPerPage = 5;
            var paginatedProducts = products.OrderBy(x => x.ID)
                .Skip((page - 1) * productsPerPage)
                .Take(productsPerPage);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = Math.Ceiling((decimal)products.Count / productsPerPage);
            return View(paginatedProducts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesForDropdown();
            ViewBag.Colors = GetColorsForDropdown();
            ViewBag.Brands = GetBrandsForDropdown();
            ViewBag.Genders = GetGendersForDropdown();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(productRequest);
                return RedirectToAction(nameof(Show));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details(int productID)
        {
            var productWithDetails = _productService.GetProductWithDetails(productID);
            ViewBag.Month1 = GetMonthToDelivery(3);
            ViewBag.Month2 = GetMonthToDelivery(7);
            return View(productWithDetails);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_productService.isExist(id))
            {
                UpdateProductRequest product = _productService.GetProductForUpdate(id);
                ViewBag.Categories = GetCategoriesForDropdown();
                ViewBag.Colors = GetColorsForDropdown();
                ViewBag.Brands = GetBrandsForDropdown();
                ViewBag.Genders = GetGendersForDropdown();
                return View(product);
            }

            return NotFound();
            
        }

        [HttpPost]
        public IActionResult Edit(UpdateProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(productRequest);
                return RedirectToAction(nameof(Show));
            }
            return View();
        }

        private List<SelectListItem> GetCategoriesForDropdown()
        {
            var selectedItems = new List<SelectListItem>();
            _categoryService.GetAllCategories().ToList().ForEach(cat => selectedItems.Add(new
                SelectListItem
                { Text = cat.Name, Value = cat.ID.ToString() }
            ));
            return selectedItems;
        }
        private List<SelectListItem> GetBrandsForDropdown()
        {
            var selectedItems = new List<SelectListItem>();
            _brandService.GetAllBrands().ToList().ForEach(bnd => selectedItems.Add(new
                SelectListItem
                { Text = bnd.Name, Value = bnd.ID.ToString() }
            ));
            return selectedItems;
        }
        private List<SelectListItem> GetColorsForDropdown()
        {
            var selectedItems = new List<SelectListItem>();
            _colorService.GetAllColors().ToList().ForEach(col => selectedItems.Add(new
                SelectListItem
                { Text = col.Name, Value = col.ID.ToString() }
            ));
            return selectedItems;
        }
        private List<SelectListItem> GetGendersForDropdown()
        {
            var selectedItems = new List<SelectListItem>();
            _genderService.GetAllGenders().ToList().ForEach(gen => selectedItems.Add(new
                SelectListItem
                { Text = gen.Name, Value = gen.ID.ToString() }
            ));
            return selectedItems;
        }
        private string GetMonthToDelivery(int i)
        {
            var monthNumber = DateTime.Today.AddDays(i).Month;
            switch (monthNumber)
            {
                case 1:
                    return "Ocak";
                case 2:
                    return "Şubat";
                case 3:
                    return "Mart";
                case 4:
                    return "Nisan";
                case 5:
                    return "Mayıs";
                case 6:
                    return "Haziran";
                case 7:
                    return "Temmuz";
                case 8:
                    return "Ağustos";
                case 9:
                    return "Eylül";
                case 10:
                    return "Ekim";
                case 11:
                    return "Kasım";
                case 12:
                    return "Aralık";
                default:
                    return "";
            }
        }

    }
}
