using ASUniversity.Domain.Enums;

namespace ASUniversity.Domain.Entities
{
    public class Teacher : BaseNameable
    {
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Position Position { get; set; }
        //relational
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }

    }
}
