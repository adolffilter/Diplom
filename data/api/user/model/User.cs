namespace DiplomaOborotovIS.data.api.model.user
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MidleName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Photo { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
