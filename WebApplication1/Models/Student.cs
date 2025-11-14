using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.ViewModels;

namespace WebApplication1.Models
{
    public class Student
    {
        public Student()
        {
            //Id = 100; ;
        }
        public Student(int id, string fname, string lname)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
        }
        public Student (string gender)
        {
            Id = 200;
            Gender = gender;
        }

        public int Id { get; set; } 
        public string FirstName { get; set; }
         
        public string LastName { get; set; } 
        [DataType(DataType.Date)]
        public DateOnly DateofBirth { get; set; } 
        public string Gender { get; set; } 
        public StudentType StudentType { get; set; }    // Enumeration usage.
        public string CountryofBirth { get; set; } 
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } 
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 
        public string Address { get; set; } 
        [DataType(DataType.Date)]
        public DateTime EnrolmentDate { get; set; }



        public List<string> NickNames { get; set; }   // [batalion, empire, sabiboy]

        // Assumption: in our school, a student must have ONE primary course, and many optional courses.
        // A student can have 1 class teacher.

        // RELATIONSHIP
        public TeachersDetailsViewModel ClassTeacher { get; set; }  // many to 1 mapping. a student can have one class teacher
        public Course PrimaryCourse { get; set; }      // 1 to 1 mapping. a student has one course
        public List<Course> OptionalCourses { get; set; }   // 1 to many mapping. a student can have many optional courses
    }
}
