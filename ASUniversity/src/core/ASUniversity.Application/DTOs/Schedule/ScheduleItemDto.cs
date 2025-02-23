namespace ASUniversity.Application.DTOs.Schedule
{
    public class ScheduleItemDto
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string Teacher { get; set; }
        public string Subject { get; set; }
        public TimeSpan StartTime { get; set; }
        public string Classroom { get; set; }
        public string DayOfWeek { get; set; }
    }
}
