using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class TeachersController : Controller
    {
        private static List<Teachers> TeachersDatabase = new List<Teachers>()
       {
           new Teachers {Id=1, FirstName ="Default", LastName = "Teacher", Email = "DefaultT@gmail.com", Department="Default Dept"}
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
            TeachersDatabase.Add(new Teachers()
            { 
                Id = id,
                FirstName = model.FirstName,
                LastName = model.LastName,
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
                 
               return RedirectToAction("Index"); 
            }

            
            var TeacherDetails = new TeachersDetailsViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Department = model.Department
            };


            return View(TeacherDetails);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var existingteacher = TeachersDatabase.FirstOrDefault(Teacher => Teacher.Id == id);
            if (existingteacher == null)
            {
               return RedirectToAction("Index");
            }
            var model = new EditTeachersViewModel()
            {
                Id = existingteacher.Id,
                FirstName = existingteacher.FirstName,
                LastName = existingteacher.LastName,
                Email = existingteacher.Email,
                Department = existingteacher.Department


            };



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditTeachersViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return NotFound();
            }

            var existingTeacher = TeachersDatabase.FirstOrDefault(Teacher => Teacher.Id == model.Id);
            if (existingTeacher == null)
            {
                return NotFound();
            }

            model.Id = existingTeacher.Id;
            model.FirstName = existingTeacher.FirstName;
            model.LastName = existingTeacher.LastName;
            model.Email = existingTeacher.Email;
            model.Department = existingTeacher.Department;




            return RedirectToAction("Details", new { id = model.Id }); 
        }

        [HttpGet]
        
        public IActionResult Delete(int id)
        {
            var model =  TeachersDatabase.FirstOrDefault(Teachers=> Teachers.Id == id);

            if (model == null) 
            { 
                RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(TeachersDetailsViewModel model)
        {
            var existingTeacher = TeachersDatabase.FirstOrDefault(Teacher => Teacher.Id == model.Id);
            if (existingTeacher == null)
            {
                return NotFound();
            }
            TeachersDatabase.Remove(existingTeacher);
           return RedirectToAction("Index");
        }
    }
}
