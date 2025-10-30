﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TeachersCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is Required")]
        public string Name { get; set; }


        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "The Department field is Required")]
        public string Department { get; set; }
    }
}
