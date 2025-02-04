namespace ASUniversity.Domain.Entities
{
    public class Specialization : BaseNameable
    {

        //relational
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Student> Students { get; set; }



    }
}
