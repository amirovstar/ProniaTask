using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P137PRONIA2.DataAccess.P137Pronia.DataAccess;
using P137PRONIA2.Models;
using P137PRONIA2.Services.Interfaces;
using P137PRONIA2.ViewModels.IndexVMs;

namespace P137PRONIA2.Controllers;


    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;

        private readonly IProductService _productService;
        public HomeController(ISliderService sliderService, IProductService productService)
        {
            _sliderService = sliderService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVm vm = new()
            {
                Sliders = await _sliderService.GetAll(),
                Products = await _productService.GetAll(false)
            };
            return View(vm);
        }
    }

