namespace ASUniversity.Application.DTOs.Exam
{
    public class ExamItemDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Group
        {
            get; set;
        }
        public string Teacher { get; set; }

        public string Type { get; set; }
    }
}
