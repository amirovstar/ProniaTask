using System;
using P137PRONIA2.Models;
using P137PRONIA2.ViewModels.SliderVMs;

namespace P137PRONIA2.Services.Interfaces;


public interface ISliderService
{
    Task Create(CreateSliderVM sliderVM);
    Task Update(UpdateSliderVM sliderVM);
    Task Delete(int? id);
    Task<ICollection<Slider>> GetAll();
    Task<Slider> GetById(int? id);
}

