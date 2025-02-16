using ASUniversity.Application.DTOs.Specialization;

namespace ASUniversity.Application.DTOs.Group
{
    public class GroupUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecializationId { get; set; }
        public IEnumerable<SpecializationItemDto> Specializations { get; set; }
    }
}
