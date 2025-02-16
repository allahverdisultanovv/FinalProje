using ASUniversity.Domain.Enums;

namespace ASUniversity.Domain.Entities
{
    public class Teacher : AppUser
    {
        public Position Position { get; set; }
        //relational

        public IEnumerable<Exam> Exams { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }

    }
}
