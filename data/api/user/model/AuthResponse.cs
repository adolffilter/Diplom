using System;

namespace DiplomaOborotovIS.data.api.model.user
{
    internal class AuthResponse
    {
        public string Access_token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
