using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DbEntities
{ 
    public class CourseEntity
    {
        public int Id { get; set; }    
        public string CourseCode { get; set; }   
        public string CourseDescription { get; set; }  
    }

    //public class Phone
    //{
    //    [Key]
    //    public int PhoneId { get; set; }
    //    public string Make { get; set; }
    //    public string Model { get; set; }
    //    public string Color { get; set; }
    //}
}
