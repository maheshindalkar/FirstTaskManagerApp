using System;

namespace TaskManager.Model
{
    public class UserTaskModel
    {
        public int UserTaskId { get; set; }
        public int ParentId { get; set; }
        public string Task { get; set; }
        public string ParentTask { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
    }
}
