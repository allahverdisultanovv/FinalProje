namespace ASUniversity.Application.DTOs.Schedule
{
    public class ScheduleItemDto
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string Teacher { get; set; }
        public string Subject { get; set; }
        public string Room { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
    }
}
