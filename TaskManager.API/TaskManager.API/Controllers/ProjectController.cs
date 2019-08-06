using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Http.Cors;
using TaskManager.Business;
using TaskManager.Model;

namespace TaskManager.API.Controllers
{
    [RoutePrefix("api/Project")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController, IDisposable
    {
        // GET api/values
        public List<ProjectModel> GetTaskDetails()
        {
            try
            {
                using (var project = new ProjectsOperations())
                {

                    return project.GetProjectDetails();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        // POST api/values
        public void Post([FromBody]ProjectModel record)
        {
            try
            {
                using (var projectOperation = new ProjectsOperations())
                {
                    var opSuccess = projectOperation.InsertProjectDetail(record);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/values/5
        public void Put([FromBody]ProjectModel record)
        {
            try
            {
                using (var projectOpertaion = new ProjectsOperations())
                {
                    var opSuccess = projectOpertaion.UpdateProjectDetail(record);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            try
            {
                using (var projectOperation = new ProjectsOperations())
                {
                    var opSuccess = projectOperation.DeleteProjectById(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}