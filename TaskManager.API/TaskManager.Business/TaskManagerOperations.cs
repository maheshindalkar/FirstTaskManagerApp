using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL;
using TaskManager.Model;

namespace TaskManager.Business
{
    public class TaskManagerOperations : IDisposable
    {
        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<UserTaskModel> GetTaskDetails()
        {
            try
            {
                using (var repository = new TaskManagerRepository())
                {
                    var taskdetails = repository.GetTaskDetails();
                    return taskdetails;
               }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserTaskModel GetTaskDetailsById(int id)
        {
            try
            {
                using (var repository = new DAL.TaskManagerRepository())
                {
                    return repository.GetTaskDetailsById(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertTask(UserTaskModel taskEntity)
        {
            try
            {
               using (var repository = new DAL.TaskManagerRepository())
                {
                   return repository.Insert(taskEntity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateTask(UserTaskModel taskEntity)
        {
            try
            {
                using (var repository = new DAL.TaskManagerRepository())
                {
                    return repository.Update(taskEntity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteTaskById(int taskId)
        {
            try
            {
                using (var repository = new DAL.TaskManagerRepository())
                {
                    return repository.DeleteById(taskId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
