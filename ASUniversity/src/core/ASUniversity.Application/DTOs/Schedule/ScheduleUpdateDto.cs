using ASUniversity.Application.DTOs.Group;
using ASUniversity.Application.DTOs.Subject;
using ASUniversity.Application.DTOs.Teacher;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace ASUniversity.Application.DTOs.Schedule
{
    public class ScheduleUpdateDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Classroom { get; set; }
        public int TeacherId { get; set; }
        [Required]
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public IEnumerable<SubjectItemDto>? Subjects { get; set; }
        public IEnumerable<SelectListItem>? DayOfWeeks { get; set; }
        public IEnumerable<GroupItemDto>? Groups { get; set; }
        public IEnumerable<TeacherItemDto>? Teachers { get; set; }
    }
}
