﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
