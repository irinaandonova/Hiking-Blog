using System.ComponentModel.DataAnnotations;

namespace NatureBlog.Application.Dto.User
{
    public class UserGetDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [Required]
        public int HikingSkill { get; set; }
    }
}
