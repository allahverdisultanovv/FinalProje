namespace ASUniversity.Application.DTOs.Teacher
{
    public record GetTeacherDto(
     string Faculty,
     string Position,
     string Name,
     string Surname,
     string Email,
     int Commencement,
     string Username,
     string Image,
     DateTime BirthDay,
     int Age,
     string Description,
     int Exprience);
}
