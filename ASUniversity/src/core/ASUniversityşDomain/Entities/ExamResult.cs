namespace ASUniversity.Domain.Entities
{
    public class ExamResult : BaseEntity
    {
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        //relational
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public IEnumerable<StudentExamResults> StudentExamResults { get; set; }

    }
}
