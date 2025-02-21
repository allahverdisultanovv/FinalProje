using ASUniversity.Application.DTOs.Group;
using ASUniversity.Application.DTOs.Subject;
using ASUniversity.Application.DTOs.Teacher;
using ASUniversity.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ASUniversity.Application.DTOs.Exam
{
    public class ExamUpdateDto
    {
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        public ExamType ExamType { get; set; }
        [Required]
        [MaxLength(4)]
        public string Classroom { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]

        public int SubjectId { get; set; }
        [Required]

        public int GroupId { get; set; }
        public IEnumerable<SubjectItemDto>? Subjects { get; set; }

        public IEnumerable<TeacherItemDto>? Teachers { get; set; }
        public IEnumerable<GroupItemDto>? Groups { get; set; }
        public IEnumerable<SelectListItem> ExamTypes { get; set; }
    }
}
