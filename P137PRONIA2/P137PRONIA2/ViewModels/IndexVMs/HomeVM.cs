using System;
using P137PRONIA2.Models;

namespace P137PRONIA2.ViewModels.IndexVMs
{
    public class HomeVm
    {
        public ICollection<Slider> Sliders { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

