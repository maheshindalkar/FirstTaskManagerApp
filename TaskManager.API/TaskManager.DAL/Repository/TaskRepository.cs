using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using TaskManager.Model;
namespace TaskManager.DAL
{
    public class TaskRepository : ITaskManagerRepository<TaskModel>, IDisposable
    {
        public TaskRepository()
        {
        }
        public bool Insert(TaskModel userTaskModel)
        {
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                    var userTask = new Task()
                    {
                        ParentTask = userTaskModel.ParentTask,
                        TasksDetail = userTaskModel.Task,
                        StartDate = userTaskModel.StartDate,
                        EndDate = userTaskModel.EndDate,
                        Priority = userTaskModel.Priority,
                        Project = userTaskModel.Project,
                        Status = userTaskModel.Status
                    };

                    context.Tasks.Add(userTask);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public List<TaskModel> GetDetails()
        {
            List<TaskModel> taskModelList;
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                    taskModelList = (from u in context.Tasks
                                     select new TaskModel()
                                     {
                                         TaskId = u.TaskId,
                                         Task = u.TasksDetail,
                                         ParentTask = u.ParentTask,
                                         EndDate = u.EndDate,
                                         StartDate = u.StartDate,
                                         Priority = u.Priority,
                                         Project = u.Project
                                     }).OrderByDescending(a => a.TaskId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taskModelList;
        }

        public bool Update(TaskModel userTaskModel)
        {
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                    var taskModel = (from c in context.Tasks
                                     where c.TaskId == userTaskModel.TaskId
                                     select c).FirstOrDefault();
                    if(taskModel == null)
                    {
                        return false;
                    }
                    taskModel.TasksDetail = userTaskModel.Task;
                    taskModel.Priority = userTaskModel.Priority;
                    taskModel.StartDate = userTaskModel.StartDate;
                    taskModel.StartDate = userTaskModel.EndDate;
                    taskModel.Status = userTaskModel.Status;
                    taskModel.Project = userTaskModel.Project;

                    context.Tasks.Add(taskModel);
                    context.Entry(taskModel).State = EntityState.Modified;
                    context.SaveChanges();
                                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool DeleteById(int id)
        {
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                    var taskModel = (from c in context.Tasks
                                     where c.TaskId == id
                                     select c).FirstOrDefault();
                    if (taskModel == null)
                    {
                        return false;
                    }
                    context.Tasks.Remove(taskModel);
                    context.Entry(taskModel).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
