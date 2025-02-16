using ASUniversity.Domain.Enums;

namespace ASUniversity.Domain.Entities
{
    public class Student : AppUser
    {
        public Degree Degree { get; set; }
        public int AdmissionYear { get; set; }

        //relational


        public int GroupId { get; set; }
        public int SpecializationId { get; set; }

        public Group Group { get; set; }
        public Specialization Specialization { get; set; }
        public IEnumerable<StudentExamResults> StudentExamResults { get; set; }

    }
}
