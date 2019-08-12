using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        public string ParentTask { get; set; }

        public string Project { get; set; }

        public string User { get; set; }

        public string TasksDetail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }

        public string Status { get; set; }

        //public Parent ParentTask { get; set; }

        //public Project Projects { get; set; }

        //public Users Users { get; set; }
    }
}
