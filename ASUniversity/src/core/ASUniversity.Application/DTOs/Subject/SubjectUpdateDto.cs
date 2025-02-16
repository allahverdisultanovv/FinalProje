using ASUniversity.Application.DTOs.Faculty;

namespace ASUniversity.Application.DTOs.Subject
{
    public record SubjectUpdateDto()
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public int FacultyId { get; set; }
        public IEnumerable<FacultyItemDto>? Faculties { get; set; }


    }
}
