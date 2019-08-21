using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using TaskManager.Model;
namespace TaskManager.DAL
{
    public class ProjectRepository : ITaskManagerRepository<ProjectModel>, IDisposable
    {
        public ProjectRepository()
        {
        }
        public bool Insert(ProjectModel userModel)
        {
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                    var project = new Project()
                    {
                        Projects = userModel.Projects,
                        Priority = userModel.Priority,
                        ManagerId = userModel.ManagerId,
                        StartDate = userModel.StartDate,
                        EndDate = userModel.EndDate,
                    };
                    context.Projects.Add(project);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public List<ProjectModel> GetDetails()
        {
            List<ProjectModel> projectModel;
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                    projectModel = (from u in context.Projects
                                 select new ProjectModel()
                                 {
                                     ProjectId = u.ProjectId,
                                     Projects = u.Projects,
                                     Priority = u.Priority,
                                     StartDate = u.StartDate,
                                     EndDate = u.EndDate,
                                     ManagerId = u.ManagerId
                                 }).OrderByDescending(a => a.ProjectId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return projectModel;
        }

        public bool Update(ProjectModel userTaskModel)
        {
            try
            {
                using (var context = new TaskManagerDbContext())
                {
                    var projectModel = (from c in context.Projects
                                     where c.ProjectId == userTaskModel.ProjectId
                                     select c).FirstOrDefault();
                    if (projectModel == null)
                    {
                        return false;
                    }
                    projectModel.Projects = userTaskModel.Projects;
                    projectModel.Priority = userTaskModel.Priority;
                    projectModel.ManagerId = userTaskModel.ManagerId;
                    projectModel.StartDate = userTaskModel.StartDate;
                    projectModel.EndDate = userTaskModel.EndDate;

                    context.Projects.Add(projectModel);
                    context.Entry(projectModel).State = EntityState.Modified;
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
                    var projectModel = (from c in context.Projects
                                     where c.ProjectId == id
                                     select c).FirstOrDefault();
                    if(projectModel == null)
                    {
                        return false;
                    }
                    context.Projects.Remove(projectModel);
                    context.Entry(projectModel).State = EntityState.Deleted;
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
