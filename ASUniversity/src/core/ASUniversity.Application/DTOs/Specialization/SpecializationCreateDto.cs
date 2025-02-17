using ASUniversity.Application.DTOs.Faculty;
using System.ComponentModel.DataAnnotations;

namespace ASUniversity.Application.DTOs.Specialization
{
    public class SpecializationCreateDto
    {
        [Required(ErrorMessage = "Name cant empty")]
        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "Name only can be letters")]
        public string Name { get; set; }
        [Required]
        public int FacultyId { get; set; }
        public IEnumerable<FacultyItemDto>? Faculties { get; set; }
    }
}
