﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockstarsHealthCheckVisualization.Models;
using System.Diagnostics;

namespace RockstarsHealthCheckVisualization.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Date date = new Date();
            date.GetLatestDate();
            ViewBag.latest = date.latestDateTime;

            return View();
        }

        [HttpPost]
        public IActionResult Checkpoint()
        {
            Date date = new Date();

            date.GetLatestDate();
            ViewBag.latest = date.latestDateTime;
            date.checkpoint = DateTime.Now;
            date.DateTimeDataBase();

            return View("Index", date);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}