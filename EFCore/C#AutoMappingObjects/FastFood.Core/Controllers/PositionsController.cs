namespace FastFood.Web.Controllers
{
    using FastFood.Services.Data;
    using FastFood.Web.ViewModels.Positions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class PositionsController : Controller
    {
        private readonly IPositionsService positionsService;

        public PositionsController(IPositionsService positionsService)
        {
            this.positionsService = positionsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await this.positionsService.CreateAsync(model);

            return RedirectToAction("All", "Positions");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<PositionsAllViewModel> positions = 
                await this.positionsService.GetAllAsync();

            return View(positions.ToList());
        }
    }
}