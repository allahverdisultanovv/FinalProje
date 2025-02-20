using ASUniversity.Domain.Enums;

namespace ASUniversity.Domain.Entities
{
    public class Student : BaseEntity
    {
        public Degree Degree { get; set; }
        public int AdmissionYear { get; set; }

        //relational
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public IEnumerable<StudentExamResults> StudentExamResults { get; set; }

    }
}
