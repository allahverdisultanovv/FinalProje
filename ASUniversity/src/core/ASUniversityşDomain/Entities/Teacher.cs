using ASUniversity.Domain.Enums;

namespace ASUniversity.Domain.Entities
{
    public class Teacher : BaseEntity
    {

        public Position Position { get; set; }
        public int Commencement { get; set; }
        public int Experience { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        //relational
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }

    }
}
