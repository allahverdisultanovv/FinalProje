using System.ComponentModel.DataAnnotations;

namespace ASUniversity.Application.DTOs.Faculty
{
    public class FacultyUpdateDto()
    {
        [Required(ErrorMessage = "Name cant empty")]
        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "Name only can be letters")]
        public string Name { get; set; }
    }

}
