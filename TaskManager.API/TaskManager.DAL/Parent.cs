using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL
{
    public class Parent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParentId { get; set; }
        public string ParentTaskDetail { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }

    }
}
