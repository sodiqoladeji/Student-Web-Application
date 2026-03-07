using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApplication1.Data;
using WebApplication1.DbEntities;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Assignment:
    /// 1. Ensure the details page load the correct student by Id.
    /// 2. Remove the unused codes and commented out codes.
    /// 3. Implement a similar dummy db for Teachers. make sure to use a proper naming for the classes.
    ///  CreateModel, DetailsMode, ListModel etc
    /// </summary>
    public class StudentsController : Controller
    {
        //private StaticSchoolManagementDatabase database;
        private readonly SchoolDbContext dbContext;
        public StudentsController()
        {
            //database = new StaticSchoolManagementDatabase();
            dbContext = new SchoolDbContext();
        }

        private static List<string> CountryList = new List<string>
        {
            "United States",
            "United Kingdom",
            "Canada",
            "Nigeria",
            "Ghana",
            "India"
        };
        public IActionResult Index()
        {

            //var allStudents = database.StudentsTable;
            var allStudents = dbContext.Students.ToList();

            return View(allStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // provide countries for the dropdown
            ViewBag.Countries = new SelectList(CountryList);
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            // Models folder: for Database representations.


            // 1. validate the input
            // process the creation (add the new student to the database)
            if (ModelState.IsValid == false)
            {
                // re-populate countries if we re-render the form
                ViewBag.Countries = new SelectList(CountryList, model?.CountryofBirth);
                // at this point, the modelstate is invalid
                // meaning at least one of the form fields is not passing validation rules
                // reload the form with the same data passed in
                // and show the validation errors
                return View(model);
            }

            // if we get here, then the modelstate is valid and we passed all validation rules
            // and now we can add the new student to the database

            // generate a random id for the new student
            //int id = database.StudentsTable.Last().Id + 1; // new Random().Next(1, 100);
            // R in CRUD = reading.
            int id = dbContext.Students.OrderBy(x => x.Id).Last().Id + 1;
            //var mappedStudent = new Student()
            //{
            //    Id = id,
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    DateofBirth = model.DateofBirth,
            //    Gender = model.Gender,
            //    CountryofBirth = model.CountryofBirth,
            //    PhoneNumber = model.PhoneNumber,
            //    Email = model.Email,
            //    Address = model.Address,
            //    ProfilePicture = model.ProfilePicture,  
            //    EnrolmentDate = DateTime.Now,
            //};
            var mappedStudentEntity = new StudentEntity()
            {
                //Id = id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                AddressLine1 = model.Address,
            };
            //database.StudentsTable.Add(mappedStudent);
            // C in CRUD = creating
            dbContext.Students.Add(mappedStudentEntity);
            dbContext.SaveChanges();    // Very important to call this method after making changes to the database context, otherwise the changes won't be persisted to the database.

            return RedirectToAction("Index");

            ViewBag.Message = "Student created successfully";
            
        }

        public IActionResult Details(int id)
        {

            //var studentRecord = database.StudentsTable.FirstOrDefault(student => student.Id == id);
            var studentRecord = dbContext.Students.FirstOrDefault(student => student.Id == id);
            if (studentRecord == null)
            {
                RedirectToAction("Index");
            }
            var model = new StudentDetailViewModel()
            {
                Id = studentRecord.Id,
                FirstName = studentRecord.FirstName,
                LastName = studentRecord.LastName,
                //DateofBirth = studentRecord.DateofBirth,
                //CountryofBirth = studentRecord.CountryofBirth,
                PhoneNumber = studentRecord.PhoneNumber,
                Email = studentRecord.Email,
                //Address = studentRecord.Address,
                //ProfilePicture = studentRecord.ProfilePicture,  
                //EnrolmentDate = studentRecord.EnrolmentDate,
                //ClassTeacher = studentRecord.ClassTeacher,
                //PrimaryCourse = studentRecord.PrimaryCourse,
                //OptionalCourses = studentRecord.OptionalCourses

                ClassTeacher = new Teachers(),
                PrimaryCourse = new Course(),
                OptionalCourses = new List<Course>()
            };

            
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var studentRecord = database.StudentsTable.FirstOrDefault(s=>s.Id == id);
            var studentRecord = dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (studentRecord == null) 
            { 
                return NotFound();
            }

            var model = new EditStudentViewModel()
            {
                Id = studentRecord.Id,
                FirstName = studentRecord.FirstName,
                LastName = studentRecord.LastName,
                //DateofBirth = studentRecord.DateofBirth,
                //Gender = studentRecord.Gender,
                //CountryofBirth = studentRecord.CountryofBirth,
                PhoneNumber = studentRecord.PhoneNumber,
                Email = studentRecord.Email,
                //Address = studentRecord.Address,
                //ProfilePicture = studentRecord.ProfilePicture, 
            };
            // supply countries and set selected to the existing value
            ViewBag.Countries = new SelectList(CountryList, model.CountryofBirth);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditStudentViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                // re-populate countries when form re-displays with errors
                ViewBag.Countries = new SelectList(CountryList, model?.CountryofBirth);
                return View(model);
            }

            //var existingstudent = database.StudentsTable.FirstOrDefault(s => s.Id == model.Id);
            var existingstudent = dbContext.Students.FirstOrDefault(s => s.Id == model.Id);
            if (existingstudent == null)
            {
                return NotFound();
            }
            existingstudent.Id = model.Id;
            existingstudent.FirstName = model.FirstName;
            existingstudent.LastName = model.LastName;
            //existingstudent.DateofBirth = model.DateofBirth;
            //existingstudent.CountryofBirth = model.CountryofBirth;
            //existingstudent.Gender = model.Gender;
            existingstudent.PhoneNumber = model.PhoneNumber;
            existingstudent.AddressLine1 = model.Address;
            //existingstudent.Email = model.Email;
            //existingstudent.ProfilePicture = model.ProfilePicture;  
            //existingstudent.EnrolmentDate = DateTime.Now;

            dbContext.Students.Update(existingstudent);
            dbContext.SaveChanges();

            return RedirectToAction("Details", new { id = model.Id });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var model = database.StudentsTable.FirstOrDefault(s => s.Id == id);
            var model = dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (ModelState.IsValid == false) 
            {
                return NotFound();
            }
            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StudentDetailViewModel model)
        {
            //var existingstudent = database.StudentsTable.FirstOrDefault(s => s.Id == model.Id);
            var existingstudent = dbContext.Students.FirstOrDefault(s => s.Id == model.Id);
            if (existingstudent == null) 
            {
                return NotFound();
            }

            //database.StudentsTable.Remove(existingstudent);
            dbContext.Students.Remove(existingstudent);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
