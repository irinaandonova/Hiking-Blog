using System.ComponentModel.DataAnnotations;

namespace Application.Dto.User
{
    public class UserPostDto
    {
        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(320)]
        public string Email { get; set; }

        [Required]
        public int HikingSkill { get; set; }
    }
}
