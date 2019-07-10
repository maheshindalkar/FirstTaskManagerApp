using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using TaskManager.Model;

namespace TaskManager.DAL
{
    public class TaskManagerRepository : ITaskManagerRepository<UserTaskModel>, IDisposable
    {
        public TaskManagerRepository()
        {
        }
        public bool Insert(UserTaskModel userTaskModel)
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

                    var userTask = new UserTask()
                    {
                        ParentTaskId = parentId,
                        TaskDetail = userTaskModel.Task,
                        StartDate = userTaskModel.StartDate,
                        EndDate = userTaskModel.EndDate,
                        Priority = userTaskModel.Priority,
                    };

                    context.UserTasks.Add(userTask);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public List<UserTaskModel> GetTaskDetails()
        {
            List<UserTaskModel> taskModelList;
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                    taskModelList = (from u in context.UserTasks
                                     join p in context.ParentTasks on u.ParentTaskId equals p.ParentId
                                     select new UserTaskModel()
                                     {
                                         UserTaskId = u.UserTaskId,
                                         ParentId = p.ParentId,
                                         Task = u.TaskDetail,
                                         ParentTask = p.ParentTaskDetail,
                                         EndDate = u.EndDate,
                                         StartDate = u.StartDate,
                                         Priority = u.Priority
                                     }).OrderByDescending(a => a.UserTaskId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taskModelList;
        }

        public UserTaskModel GetTaskDetailsById(int id)
        {
            UserTaskModel taskModelList;
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                     taskModelList = (from u in context.UserTasks
                                         join p in context.ParentTasks on u.ParentTaskId equals p.ParentId
                                         where u.UserTaskId == id
                                         select new UserTaskModel()
                                         {
                                             UserTaskId = u.UserTaskId,
                                             ParentId = p.ParentId,
                                             Task = u.TaskDetail,
                                             ParentTask = p.ParentTaskDetail,
                                             EndDate = u.EndDate,
                                             StartDate = u.StartDate,
                                             Priority = u.Priority
                                         }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taskModelList;
        }

        public bool Update(UserTaskModel userTaskModel)
        {
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                    var taskModel = (from c in context.UserTasks
                                     where c.UserTaskId == userTaskModel.UserTaskId
                                     select c).FirstOrDefault();
                    taskModel.TaskDetail = userTaskModel.Task;
                    taskModel.Priority = userTaskModel.Priority;
                    taskModel.StartDate = userTaskModel.StartDate;
                    taskModel.StartDate = userTaskModel.EndDate;


                    context.UserTasks.Add(taskModel);
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
                    var taskModel = (from c in context.UserTasks
                                     where c.UserTaskId == id
                                     select c).FirstOrDefault();
                    context.UserTasks.Remove(taskModel);
                    context.Entry(taskModel).State = EntityState.Deleted;
                    context.SaveChanges();

                    var parentTaskModel = (from c in context.ParentTasks
                                           where c.ParentId == taskModel.ParentTaskId
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
