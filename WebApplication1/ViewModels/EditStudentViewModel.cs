using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class EditStudentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The FirstName field is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The LastName field is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The DateofBirth field is Required")]
        [DataType(DataType.Date)]
        public DateOnly DateofBirth { get; set; }

        [Required(ErrorMessage = "The Gender field is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "The CountryofBirth field is Required")]
        [MaxLength(56, ErrorMessage = "Country of Birth cannot exceed 56 characters")]
        public string CountryofBirth { get; set; }

        [Required(ErrorMessage = "The PhoneNumber field is Required")]
        [MaxLength(11, ErrorMessage = "Invalid Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Address field is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The Enrollment field is Required")]
        [DataType(DataType.Date)]
        public DateTime EnrolmentDate { get; set; }
    }
}
