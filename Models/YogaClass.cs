using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace YogaSix.Models
{
    public class YogaClass
    {
        [Key] 
        public int ClassId { get; set; }

        [Required(ErrorMessage = "Class name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Class size is required.")]
        [Range(1, 100, ErrorMessage = "Size must be between 1 and 100.")]
        public int Size { get; set; } = 0;

        [Required(ErrorMessage = "Challenge Level is required.")]
        public string ChallengeLevelId { get; set; } = string.Empty;

        [ValidateNever]
        public ChallengeLevel? ChallengeLevel { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;
    }
}
