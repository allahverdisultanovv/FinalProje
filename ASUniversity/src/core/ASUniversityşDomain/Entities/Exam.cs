using ASUniversity.Domain.Enums;

namespace ASUniversity.Domain.Entities
{
    public class Exam : BaseEntity
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public ExamType ExamType { get; set; }
        public string Classroom { get; set; }
        //relational
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
