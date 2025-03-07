﻿namespace ASUniversity.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Classroom { get; set; }
        //relational
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
