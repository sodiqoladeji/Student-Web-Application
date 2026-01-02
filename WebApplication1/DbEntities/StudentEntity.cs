namespace WebApplication1.DbEntities
{
    public class StudentEntity
    {
        public int Id { get; set; } // The primary key     // Id or StudentEntityId
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
