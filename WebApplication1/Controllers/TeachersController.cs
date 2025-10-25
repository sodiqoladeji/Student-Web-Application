using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult Index()
        {
            var Teachers = new List<TeachersDetailsViewModel>();
            Teachers.Add(new TeachersDetailsViewModel() 
            { 
                Name = "Carla Vaughan",
                Email = "CarlaVaughan@example.com",
                Department = "Statistics"
            });
            Teachers.Add(new TeachersDetailsViewModel()
            {
                Name = "Sue Herridge",
                Email = "SueHerridge@example.com",
                Department = "Economics"
            });
            Teachers.Add(new TeachersDetailsViewModel()
            {
                Name = "Ben Hurrel",
                Email = "BenHurrel@example.com",
                Department = "Physics"
            });
            Teachers.Add(new TeachersDetailsViewModel()
            {
                Name = "Ceci Pessoa",
                Email = "CeciPessoa@example.com",
                Department = "Business Administration"
            });
            Teachers.Add(new TeachersDetailsViewModel()
            {
                Name = "Gangha Jhurry",
                Email = "GanghaJhurry@example.com",
                Department = "Mathematics"
            });
            Teachers.Add(new TeachersDetailsViewModel()
            {
                Name = "Ben Hurrel",
                Email = "BenHurrel@example.com",
                Department = "Physics"
            });
           
            Teachers.Add(new TeachersDetailsViewModel()
            {
                Name = "Sheila Butler",
                Email = "SheilaButler@example.com",
                Department = "Management"
            });
            Teachers.Add(new TeachersDetailsViewModel()
            {
                Name = "Sue Herridge",
                Email = "SueHerridge@example.com",
                Department = "Economics"
            });
            Teachers.Add(new TeachersDetailsViewModel()
            {
                Name = "Ben Hurrel",
                Email = "BenHurrel@example.com",
                Department = "Physics"
            });


            return View(Teachers);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeachersDetailsViewModel model)
        {
            return View();
        }

        public IActionResult Details()
        {
            var TeachersModel = new TeachersDetailsViewModel();
            TeachersModel.Name = "Ben Hurrel";
            TeachersModel.Email = "BenHurrel@example.com";
            TeachersModel.Department = "Physics";

            return View(TeachersModel);
        }
    }
}
