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
                    var parentEntity = new Parent()
                    {
                        ParentTaskDetail = userTaskModel.ParentTask
                    };
                    context.ParentTasks.Add(parentEntity);
                    context.SaveChanges();
                    int parentId = parentEntity.ParentId;

                    var userTask = new Task()
                    {
                        ParentId = userTaskModel.ParentId,
                        TasksDetail = userTaskModel.Task,
                        StartDate = userTaskModel.StartDate,
                        EndDate = userTaskModel.EndDate,
                        Priority = userTaskModel.Priority,
                        ProjectId = userTaskModel.ProjectId,
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
                                     join p in context.ParentTasks on u.ParentId equals p.ParentId
                                     select new TaskModel()
                                     {
                                         TaskId = u.TaskId,
                                         ParentId = p.ParentId,
                                         Task = u.TasksDetail,
                                         ParentTask = p.ParentTaskDetail,
                                         EndDate = u.EndDate,
                                         StartDate = u.StartDate,
                                         Priority = u.Priority
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
                    taskModel.TasksDetail = userTaskModel.Task;
                    taskModel.Priority = userTaskModel.Priority;
                    taskModel.StartDate = userTaskModel.StartDate;
                    taskModel.StartDate = userTaskModel.EndDate;
                    taskModel.Status = userTaskModel.Status;

                    context.Tasks.Add(taskModel);
                    context.Entry(taskModel).State = EntityState.Modified;
                    context.SaveChanges();

                    var parentTaskModel = (from c in context.ParentTasks
                                           where c.ParentId == userTaskModel.ParentId
                                           select c).FirstOrDefault();
                    parentTaskModel.ParentTaskDetail = userTaskModel.ParentTask;

                    context.ParentTasks.Add(parentTaskModel);
                    context.Entry(parentTaskModel).State = EntityState.Modified;
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
                    context.Tasks.Remove(taskModel);
                    context.Entry(taskModel).State = EntityState.Deleted;
                    context.SaveChanges();

                    var parentTaskModel = (from c in context.ParentTasks
                                           where c.ParentId == taskModel.ParentId
                                           select c).FirstOrDefault();
                    context.ParentTasks.Remove(parentTaskModel);
                    context.Entry(parentTaskModel).State = EntityState.Deleted;
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
