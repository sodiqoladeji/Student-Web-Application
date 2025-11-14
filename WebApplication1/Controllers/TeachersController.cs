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
        private StaticSchoolManagementDatabase database;

        public TeachersController()
        {
            database = new StaticSchoolManagementDatabase();
        }
         

        public IActionResult Index()
        {
            //var std1 = new Student();
            //std1.FirstName = "John";
            //std1.LastName = "Doe";
            //std1.Id = 1;

            //var std2 = new Student(2, "Sodiq", "Yusuff");
            //var std3 = new Student(3, "Charles", "Olumo");

            //var std4 = new Student("MALE");

            var allTeachers = database.TeachersTable;
            return View(allTeachers);
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

            int id = database.TeachersTable.Last().Id + 1;
            database.TeachersTable.Add(new Teachers()
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
            var model = database.TeachersTable.FirstOrDefault(Teacher => Teacher.Id == id);
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
            var existingteacher = database.TeachersTable.FirstOrDefault(Teacher => Teacher.Id == id);
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

            var existingTeacher = database.TeachersTable.FirstOrDefault(Teacher => Teacher.Id == model.Id);
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
            var model = database.TeachersTable.FirstOrDefault(Teachers=> Teachers.Id == id);

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
            var existingTeacher = database.TeachersTable.FirstOrDefault(Teacher => Teacher.Id == model.Id);
            if (existingTeacher == null)
            {
                return NotFound();
            }
            database.TeachersTable.Remove(existingTeacher);
           return RedirectToAction("Index");
        }
    }
}
