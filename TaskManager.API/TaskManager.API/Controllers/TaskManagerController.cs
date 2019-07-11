using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Http.Cors;
using TaskManager.Business;
using TaskManager.Model;

namespace TaskManager.API.Controllers
{
    [RoutePrefix("api/TaskManager")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskManagerController : ApiController, IDisposable
    {
        // GET api/values
        public List<UserTaskModel> GetTaskDetails()
        {
            try
            {
               using (var task = new TaskManagerOperations())
                {

                    return task.GetTaskDetails();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //[Route("GetTaskDetailsById/{id}")]
        public UserTaskModel GetTaskDetailsById(int id)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {

                    return task.GetTaskDetailsById(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       // POST api/values
        public void Post([FromBody]UserTaskModel record)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                    var opSuccess = task.InsertTask(record);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/values/5
        public void Put([FromBody]UserTaskModel record)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                    var opSuccess = task.UpdateTask(record);
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
                using (var task = new TaskManagerOperations())
                {
                    var opSuccess = task.DeleteTaskById(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}