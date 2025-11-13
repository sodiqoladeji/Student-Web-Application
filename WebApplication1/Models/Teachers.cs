using System.Collections.Generic;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
       
        public string Title { get; set; }

        public List<Student> PrimaryClass { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }




    }
}
