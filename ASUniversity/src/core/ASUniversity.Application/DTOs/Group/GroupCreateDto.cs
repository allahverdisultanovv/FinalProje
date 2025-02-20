using ASUniversity.Application.DTOs.Specialization;
using System.ComponentModel.DataAnnotations;

namespace ASUniversity.Application.DTOs.Group
{
    public class GroupCreateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cant empty")]
        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "Name only can be letters")]
        [MaxLength(10)]
        public string Name { get; set; }
        public int SpecializationId { get; set; }
        public IEnumerable<SpecializationItemDto>? Specializations { get; set; }
    }
}
