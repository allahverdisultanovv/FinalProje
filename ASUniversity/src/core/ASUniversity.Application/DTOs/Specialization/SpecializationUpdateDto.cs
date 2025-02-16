using ASUniversity.Application.DTOs.Faculty;

namespace ASUniversity.Application.DTOs.Specialization
{
    public class SpecializationUpdateDto
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public IEnumerable<FacultyItemDto>? Faculties { get; set; }
    }
}
