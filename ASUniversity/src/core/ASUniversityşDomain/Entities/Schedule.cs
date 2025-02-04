namespace ASUniversity.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public string DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Classroom { get; set; }
        //relational
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
