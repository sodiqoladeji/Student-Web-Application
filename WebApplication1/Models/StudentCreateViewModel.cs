using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StudentCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

         
        public DateTime EnrolmentDate { get; set; } 

    }

}
