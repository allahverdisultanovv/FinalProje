using ASUniversity.Application.DTOs.Specialization;

namespace ASUniversity.Application.DTOs.Group
{
    public class GroupCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecializationId { get; set; }
        public IEnumerable<SpecializationItemDto>? Specializations { get; set; }
    }
}
