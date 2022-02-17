namespace Core.Concrete
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; } = new string[] { "Default" };
        public UserContact UserContact { get; set; }
        public short Status { get; set; } = 1;
    }
}
