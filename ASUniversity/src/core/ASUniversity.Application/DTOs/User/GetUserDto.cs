using ASUniversity.Application.DTOs.Student;
using ASUniversity.Application.DTOs.Teacher;

namespace ASUniversity.Application.DTOs.User
{
    public class GetUserDto
    {
        public GetTeacherDto? Teacher { get; set; }
        public GetStudentDto? Student { get; set; }


    }
}
