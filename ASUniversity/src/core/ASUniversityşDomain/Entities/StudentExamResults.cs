namespace ASUniversity.Domain.Entities
{
    public class StudentExamResults
    {
        public int ExamResultId { get; set; }
        public ExamResult ExamResult { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
