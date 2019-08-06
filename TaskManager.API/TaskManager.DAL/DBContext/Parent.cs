using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL
{
    public class Parent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParentId { get; set; }
        public string ParentTaskDetail { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
