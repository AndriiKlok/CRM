using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using CRM_SYSTEM.BLL;
using CRM_SYSTEM.DAO;
using CRM_SYSTEM.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        [HttpPost("[action]")]
        public TaskModel AddTask([FromBody]TaskModel post)
        {
            try
            {
                if (post.guid == null) return new TaskModel { error = "User is not logined" };

                DataTable dt = DAOCRM.AddTask(post.guid, post.usrRealize, post.title, post.content, post.description);

                if (dt == null) return new TaskModel { error = "Application is not added" };
                if (dt.Rows.Count < 1) return new TaskModel { error = "Application is not added" };

                return new TaskModel
                {
                    nid = Convert.ToInt32(dt.Rows[0]["Tsk_Id"].ToString()),
                    sid = dt.Rows[0]["Tsk_Number"].ToString()
                };
            }
            catch (Exception ex)
            {
                SaveErrorDB.AddError(ex, new StackTrace().GetFrame(0).GetMethod().Name, MethodBase.GetCurrentMethod().DeclaringType?.FullName);
                return new TaskModel { error = ex.Message };
            }
        }

        [HttpPost("[action]")]
        public List<TaskModel> GetClientTasks([FromBody]TaskModel post)
        {
            List<TaskModel> result = new List<TaskModel>();
            try
            {
                if (post.guid == null)
                {
                    result.Add(new TaskModel { error = "User is not logined" });
                    return result;
                }

                DataTable applications = DAOCRM.ClientTasksList(post.guid);
                if(applications == null)
                {
                    result.Add(new TaskModel { error = "Error get applications list" });
                    return result;
                }

                if(applications.Rows.Count < 1)
                    return result;

                foreach(DataRow application in applications.Rows)
                {
                    TaskModel temp = new TaskModel
                    {
                        nid = Convert.ToInt32(application["Tsk_Id"].ToString()),
                        sid = application["Tsk_Number"].ToString(),
                        ntype = Convert.ToInt32(application["Tsk_Type"].ToString()),
                        stype = application["Tsk_SType"].ToString(),
                        nstate = Convert.ToInt32(application["Tsk_State"].ToString()),
                        sstate = application["Tsk_SState"].ToString(),
                        usrCreate = Convert.ToInt32(application["Tsk_UsrCreate"].ToString()),
                        usrCreateName = application["usrCreateName"].ToString(),
                        usrRealize = Convert.ToInt32(application["Tsk_UsrRealize"].ToString()),
                        usrRealizeName = application["usrRealizeName"].ToString(),
                        title = application["Tsk_Title"].ToString(),
                        content = application["Tsk_Content"].ToString(),
                        description = application["Tsk_Description"].ToString(),
                        dateCreate = application["Tsk_DateCreate"].ToString() != "" ? Convert.ToDateTime(application["Tsk_DateCreate"].ToString()) : (DateTime?)null,
                        dateRealize = application["Tsk_DateRealize"].ToString() != "" ? Convert.ToDateTime(application["Tsk_DateRealize"].ToString()): (DateTime?)null
                    };

                    result.Add(temp);
                }

                return result;
            }
            catch(Exception ex)
            {
                SaveErrorDB.AddError(ex, new StackTrace().GetFrame(0).GetMethod().Name, MethodBase.GetCurrentMethod().DeclaringType?.FullName);
                TaskModel error = new TaskModel { error = ex.Message };
                result.Add(error);
                return result;
            }
        }

        [HttpPost("[action]")]
        public List<TaskModel> GetTask([FromBody]TaskModel post)
        {
            List<TaskModel> result = new List<TaskModel>();
            try
            {
                if (post.guid == null)
                {
                    result.Add(new TaskModel { error = "User is not logined" });
                    return result;
                }

                DataTable applications = DAOCRM.GetTask(post.nid);
                if (applications == null)
                {
                    result.Add(new TaskModel { error = "Error get application" });
                    return result;
                }

                if (applications.Rows.Count < 1)
                    return result;

                foreach (DataRow application in applications.Rows)
                {
                    TaskModel temp = new TaskModel
                    {
                        nid = Convert.ToInt32(application["Tsk_Id"].ToString()),
                        sid = application["Tsk_Number"].ToString(),
                        ntype = Convert.ToInt32(application["Tsk_Type"].ToString()),
                        stype = application["Tsk_SType"].ToString(),
                        nstate = Convert.ToInt32(application["Tsk_State"].ToString()),
                        sstate = application["Tsk_SState"].ToString(),
                        usrCreate = Convert.ToInt32(application["Tsk_UsrCreate"].ToString()),
                        usrCreateName = application["usrCreateName"].ToString(),
                        usrRealize = Convert.ToInt32(application["Tsk_UsrRealize"].ToString()),
                        usrRealizeName = application["usrRealizeName"].ToString(),
                        title = application["Tsk_Title"].ToString(),
                        content = application["Tsk_Content"].ToString(),
                        description = application["Tsk_Description"].ToString(),
                        dateCreate = application["Tsk_DateCreate"].ToString() != "" ? Convert.ToDateTime(application["Tsk_DateCreate"].ToString()) : (DateTime?)null,
                        dateRealize = application["Tsk_DateRealize"].ToString() != "" ? Convert.ToDateTime(application["Tsk_DateRealize"].ToString()) : (DateTime?)null
                    };

                    result.Add(temp);
                }

                return result;
            }
            catch (Exception ex)
            {
                SaveErrorDB.AddError(ex, new StackTrace().GetFrame(0).GetMethod().Name, MethodBase.GetCurrentMethod().DeclaringType?.FullName);
                TaskModel error = new TaskModel { error = ex.Message };
                result.Add(error);
                return result;
            }
        }
    }
}