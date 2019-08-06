﻿using System;

namespace TaskManager.Model
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public int ParentId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string Task { get; set; }
        public string ParentTask { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
    }
}
