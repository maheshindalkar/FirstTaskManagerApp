using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int EmployeeId { get; set; }

        //public ICollection<Project> Projects { get; set; }

        //public ICollection<Task> Tasks { get; set; }

    }
}

