using AimHigh.BL;
using AimHigh.BL.Models;
using AimHigh.PL.Data;
using AimHigh.UI.Services.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AimHigh.UI.Controllers
{
    public class GoalController : Controller
    {

        private readonly ApiClient _apiClient;
        private readonly string _apiObjectName = "goal";

        public GoalController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        // GET: Goal
        public async Task<IActionResult> Index()
        {
            try
            {
                // Use API service to get the list of goals
                var goals = await _apiClient.GetAllAsync<Goal>(_apiObjectName);
                return View(goals); // Pass goals to the view
            }
            catch (Exception ex)
            {
                // Handle API call errors
                ViewBag.ErrorMessage = "Error fetching data from API: " + ex.Message;
                return View(new List<Goal>());
            }
        }

    }
}
