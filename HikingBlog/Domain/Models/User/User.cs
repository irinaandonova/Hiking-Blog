namespace NatureBlog.Domain.Models
{
    public class User : IUser
    {
        public readonly Guid Id;
        public User(string username, string email, int hikingSkill)
        {
            Id = Guid.NewGuid();
            Email = email;
            Username = username;
            HikingSkill = hikingSkill;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public int HikingSkill { get; set; }

        public bool IsSubscribed { get; set; } = false;

    }
}
