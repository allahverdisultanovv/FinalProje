namespace ASUniversity.Application.DTOs.Student
{
    public record GetStudentDto(string Name, int Age, DateTime BirthDay, string Username, string Email, string Surname, string Image, string Group, string Degree)
    {
    }
}
