namespace ASUniversity.Domain.Entities
{
    public class Group : BaseNameable
    {
        //relational
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
