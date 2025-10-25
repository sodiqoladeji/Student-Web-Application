using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StudentDetailViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "The Name field is Required")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Enrollment field is Required")]
        [DataType(DataType.Date)]
        public string EnrolmentDate { get; set; }
    }
}
