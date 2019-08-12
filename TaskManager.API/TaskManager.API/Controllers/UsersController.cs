﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Http.Cors;
using TaskManager.Business;
using TaskManager.Model;

namespace TaskManager.API.Controllers
{
    [RoutePrefix("api/User")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController, IDisposable
    {
        // GET api/values
        public List<UsersModel> GetTaskDetails()
        {
            try
            {
                using (var userOperation = new UsersOperations())
                {

                    return userOperation.GetUserDetails();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST api/values
        public void Post([FromBody]UsersModel record)
        {
            try
            {
                using (var userOperation = new UsersOperations())
                {
                    var opSuccess = userOperation.InsertUserDetail(record);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/values/5
        public void Put([FromBody]UsersModel record)
        {
            try
            {
                using (var userOperation = new UsersOperations())
                {
                    var opSuccess = userOperation.UpdateUserDetail(record);
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
                using (var userOperation = new UsersOperations())
                {
                    var opSuccess = userOperation.DeleteUserById(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}