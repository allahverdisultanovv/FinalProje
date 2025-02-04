namespace ASUniversity.Domain.Entities
{
    public class ExamResult : BaseEntity
    {
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        //relational
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public Student Student { get; set; }
    }
}
