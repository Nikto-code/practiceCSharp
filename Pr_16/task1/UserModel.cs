namespace task1
{
    public enum UserRole
    {
        Admin,
        User
    }

    public class UserModel
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;
    }
}