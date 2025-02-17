using ASUniversity.Domain.Enums;

namespace ASUniversity.Domain.Entities
{
    public class Teacher
    {
        public Position Position { get; set; }
        //relational
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }

    }
}
