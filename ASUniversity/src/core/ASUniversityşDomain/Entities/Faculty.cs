namespace ASUniversity.Domain.Entities
{
    public class Faculty : BaseNameable
    {
        //relational
        public IEnumerable<Specialization> Specializations { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }



    }
}
