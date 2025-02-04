namespace ASUniversity.Domain.Entities
{
    public class Subject : BaseNameable
    {
        public int Credits { get; set; }
        //relational
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }


    }
}
