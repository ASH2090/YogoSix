using System.ComponentModel.DataAnnotations;

namespace YogaSix.Models
{
    public class ChallengeLevel
    {
        [Key]
        public string ChallengeLevelId { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
