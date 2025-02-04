using ASUniversity.Domain.Enums;

namespace ASUniversity.Domain.Entities
{
    public class Student : BaseNameable
    {
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Degree Degree { get; set; }
        public int AdmissionYear { get; set; }

        //relational

        public int FacultyId { get; set; }
        public int GroupId { get; set; }
        public int SpecializationId { get; set; }

        public Group Group { get; set; }
        public Faculty Faculty { get; set; }
        public Specialization Specialization { get; set; }

    }
}
