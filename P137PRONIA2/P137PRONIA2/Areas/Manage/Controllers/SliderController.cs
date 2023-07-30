using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P137PRONIA2.DataAccess.P137Pronia.DataAccess;
using P137PRONIA2.Extensions;
using P137PRONIA2.Models;
using P137PRONIA2.Services.Interfaces;
using P137PRONIA2.ViewModels.SliderVMs;

namespace P137Pronia.Areas.Manage.Controllers;


public class SliderController : Controller
{
    private readonly ISliderService _sliderService;

    public SliderController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }
    public async Task<IActionResult> Index()
    {
        try
        {
            return View(await _sliderService.GetAll());
        }
        catch (Exception)
        {

            return NotFound();
        }
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateSliderVM sliderVM)
    {
        try
        {
            if (sliderVM.ImageFile != null)
            {
                if (!sliderVM.ImageFile.IsTypeValid("image")) ;
                ModelState.AddModelError("ImageFile", "Wrong file type");
                if (sliderVM.ImageFile.IsSizeValid(2)) ;
                ModelState.AddModelError("ImageFile", "File maximum size is 2mb");
            }
            if (!ModelState.IsValid) return View();
            await _sliderService.Create(sliderVM);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {

            return NotFound();
        }
    }
    public async Task<IActionResult> Delete(int? id)
    {
        try
        {
            await _sliderService.Delete(id);
            TempData["IsDeleted"] = true;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {

            return NotFound();
        }
    }

    public async Task<IActionResult> Update(int? id)
    {
        try
        {
            return View(await _sliderService.GetById(id));
        }
        catch (Exception)
        {

            return NotFound();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Update(int? id, UpdateSliderVM sliderVM)
    {
        try
        {
            await _sliderService.Update(sliderVM);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}