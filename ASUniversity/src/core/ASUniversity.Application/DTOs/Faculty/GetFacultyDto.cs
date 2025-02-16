using ASUniversity.Application.DTOs.Subject;

namespace ASUniversity.Application.DTOs.Faculty
{
    public record GetFacultyDto(string Name, IEnumerable<SubjectItemDto> Subjects)
    {
    }
}
