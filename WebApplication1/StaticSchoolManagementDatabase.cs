using System;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1
{
    public class StaticSchoolManagementDatabase
    {
        public List<Student> StudentsTable = new List<Student>()
        {
            new Student()
            {
              Id = 1,
              FirstName ="Default",
              LastName = "Student",
              Email = "defstd@gmail.com",
              Gender = "Female",
              EnrolmentDate = DateTime.Now,
              DateofBirth = DateOnly.MinValue,
              CountryofBirth = "Nigeria",
              PhoneNumber = "07452737326",
              Address = "London, United Kingdom",

              ClassTeacher = new TeachersDetailsViewModel()
              {
                  FirstName = "Mr class Teacher John",
                  LastName = "Doe",
                  Department = "EEE"
              },
              PrimaryCourse = new Course()
              {
                  CourseID = 1,
                  CourseCode = "MTS 101",
                  CourseDescription = "Intro to Maths"
              },
              OptionalCourses = new List<Course>
              {
                  new Course()
                  {
                      CourseID = 34,
                      CourseCode = "BIO 101",
                      CourseDescription = "Essential Biology"
                  },
                  new Course()
                  {
                      CourseID = 35,
                      CourseCode = "CHE 101",
                      CourseDescription = "Organic Chemistry."
                  }
              }

            },


            new Student()
            {
                Id = 2,
              FirstName ="Default",
              LastName = "Student",
              Email = "defstd@gmail.com",
              Gender = "Female",
              EnrolmentDate = DateTime.Now,
              DateofBirth = DateOnly.MinValue,
              CountryofBirth = "Nigeria",
              PhoneNumber = "07452737326",
              Address = "London, United Kingdom",

              ClassTeacher = new TeachersDetailsViewModel()
              {
                  FirstName = "Mr class ",
                  LastName = "Teacher John",
                  Department = "EEE"
              },
              PrimaryCourse = new Course()
              {
                  CourseID = 1,
                  CourseCode = "MTS 101",
                  CourseDescription = "Intro to Maths"
              },
              OptionalCourses = new List<Course>
              {
                  new Course()
                  {
                      CourseID = 34,
                      CourseCode = "BIO 101",
                      CourseDescription = "Essential Biology"
                  },
                  new Course()
                  {
                      CourseID = 35,
                      CourseCode = "CHE 101",
                      CourseDescription = "Organic Chemistry."
                  }
              }
            }
        };

        public List<Teachers> TeachersTable = new List<Teachers>()
        {
            new Teachers {Id=1, FirstName ="Default", LastName = "Teacher", Email = "DefaultT@gmail.com", Department="Default Dept"}
        };

        // CREATE OTHER TABLES




    }
}
