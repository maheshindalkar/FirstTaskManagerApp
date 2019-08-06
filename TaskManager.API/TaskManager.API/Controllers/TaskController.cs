using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Http.Cors;
using TaskManager.Business;
using TaskManager.Model;

namespace TaskManager.API.Controllers
{
    [RoutePrefix("api/Task")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskController : ApiController, IDisposable
    {
        // GET api/values
        public List<TaskModel> GetTaskDetails()
        {
            try
            {
               using (var task = new TaskOperations())
                {

                    return task.GetTaskDetails();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       // POST api/values
        public void Post([FromBody]TaskModel record)
        {
            try
            {
                using (var task = new TaskOperations())
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
        public void Put([FromBody]TaskModel record)
        {
            try
            {
                using (var task = new TaskOperations())
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
                using (var task = new TaskOperations())
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