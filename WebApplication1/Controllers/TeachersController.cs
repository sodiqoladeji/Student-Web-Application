using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeachersController : Controller
    {
        private static List<TeachersDetailsViewModel> TeachersDatabase = new List<TeachersDetailsViewModel>()
       {
           new TeachersDetailsViewModel{Id=1, Name ="Default Teacher", Email = "DefaultT@gmail.com", Department="Default Dept"}
       };
            
        public IActionResult Index()
        {
            


            return View(TeachersDatabase);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeachersCreateViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);

                
            }

            int id = TeachersDatabase.Last().Id + 1;
            TeachersDatabase.Add(new TeachersDetailsViewModel()
            { 
                Id = id,
                Name = model.Name,
                Email = model.Email,
                Department = model.Department
            });

            
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id) 
        {
            /*TeachersDetailsViewModel model = null;
            foreach (var Teacher in TeachersDatabase)
            {
                if (Teacher.Id == id)
                {
                   model = Teacher;
                    break;
                }
            }*/
            var model = TeachersDatabase.FirstOrDefault(Teacher => Teacher.Id == id);
            if (model == null)
            {
                 
                RedirectToAction("Index"); 
            }

            return View(model);
        }
        
    }
}
