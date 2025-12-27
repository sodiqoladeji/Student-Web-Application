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
              FirstName ="John",
              LastName = "Smith",
              Email = "JSmith@gmail.com",
              Gender = Gender.Female,  
              EnrolmentDate = DateTime.Now,
              DateofBirth = new DateOnly(2000, 1, 1),
              CountryofBirth = "Nigeria",
              PhoneNumber = "07452737326",
              Address = "London, United Kingdom",
              ProfilePicture = "https://picsum.photos/200/300",  
              ClassTeacher = new Teachers()
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
              FirstName ="Cecilia",
              LastName = "Pessoa",
              Email = "CPessoa@gmail.com",
              Gender = Gender.Female,  
              EnrolmentDate = DateTime.Now,
              DateofBirth = new DateOnly(1992,03,17),
              CountryofBirth = "Nigeria",
              PhoneNumber = "07452737326",
              Address = "London, United Kingdom",
              ProfilePicture = "https://picsum.photos/200/300",  

              ClassTeacher = new Teachers()
              {
                  FirstName = "Sheila",
                  LastName = "Butler",
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
            new Teachers {Id=1, FirstName ="Sheila", LastName = "Butler", Email = "SButler@gmail.com", Department="Physics Dept"}
        };

        // CREATE OTHER TABLES




    }
}
