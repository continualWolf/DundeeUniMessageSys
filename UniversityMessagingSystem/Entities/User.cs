namespace UniversityMessagingSystem.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? UserRoleId { get; set; }

        public string Password { get; set; }

        //public UserRole userRole { get; set; }
    }
}
