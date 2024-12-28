using AimHigh.BL;
using AimHigh.PL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AimHigh.UI.Controllers
{
    public class GoalController : Controller
    {
        private readonly DbContextOptions<AimHighEntities> options;
        private readonly GoalManager goalManager;

        public GoalController(ILogger<GoalController> logger,
                        DbContextOptions<AimHighEntities> options)
        {
            this.options = options;
            this.goalManager = new GoalManager(options);
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.Title = "Goals";
            ViewBag.Info = TempData["info"];
            return View(goalManager.Load());
        }
    }
}
