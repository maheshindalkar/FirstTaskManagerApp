using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL
{
    public class UserTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTaskId { get; set; }
        public string TaskDetail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int ParentTaskId { get; set; }

        public Parent ParentTask { get; set; }

    }
}
