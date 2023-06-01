namespace ASPNETCoreIntroduction.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ASPNETCoreIntroduction.Services.Interfaces;
    using ASPNETCoreIntroduction.Models;

    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddCarViewModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(carModel);
            }

            if (true)
            {
                ModelState.AddModelError("", "Unexpected error occurred!");
                return this.View(carModel);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
