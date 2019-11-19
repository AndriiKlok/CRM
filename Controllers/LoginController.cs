using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM_SYSTEM.Model;
using CRM_SYSTEM.DAO;
using Microsoft.AspNetCore.Mvc;
using CRM_SYSTEM.BLL;
using System.Diagnostics;
using System.Reflection;
using System.Data;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost("[action]")]
        public UserModel Login([FromBody]LoginDataModel post)
        {
            try
            {
                DataTable dt = new DataTable();

                if(post.guid != null)
                {
                    dt = DAOCRM.LoginedUser(post.guid);
                }
                else
                {
                    post.guid = Guid.NewGuid().ToString();
                    dt = DAOCRM.LoginUser(post.login, post.password, post.guid);
                }

                if (dt == null) return new UserModel { error = "Incorrect login or password"};
                if (dt.Rows.Count < 1) return new UserModel { error = "Incorrect login or password" };

                return new UserModel
                {
                    guid = post.guid,
                    id = Convert.ToInt32(dt.Rows[0]["USR_Id"].ToString()),
                    type = Convert.ToInt32(dt.Rows[0]["USR_Type"].ToString()),
                    login = dt.Rows[0]["USR_Login"].ToString(),
                    mail = dt.Rows[0]["USR_Mail"].ToString(),
                    name = dt.Rows[0]["USR_Name"].ToString()
                };

            }
            catch (Exception ex)
            {
                SaveErrorDB.AddError(ex, new StackTrace().GetFrame(0).GetMethod().Name, MethodBase.GetCurrentMethod().DeclaringType?.FullName);
                return new UserModel { error = ex.Message };
            }
        }

        [HttpPost("[action]")]
        public UserModel Logged([FromBody]BaseModel post)
        {
            try
            {
                DataTable dt = new DataTable();

                if (post.guid != null)
                    dt = DAOCRM.LoginedUser(post.guid);

                if (dt == null) return new UserModel { error = "Session has expired" };
                if (dt.Rows.Count < 1) return new UserModel { error = "Session has expired" };

                return new UserModel
                {
                    guid = post.guid,
                    id = Convert.ToInt32(dt.Rows[0]["USR_Id"].ToString()),
                    type = Convert.ToInt32(dt.Rows[0]["USR_Type"].ToString()),
                    login = dt.Rows[0]["USR_Login"].ToString(),
                    mail = dt.Rows[0]["USR_Mail"].ToString(),
                    name = dt.Rows[0]["USR_Name"].ToString()
                };
            }
            catch(Exception ex)
            {
                SaveErrorDB.AddError(ex, new StackTrace().GetFrame(0).GetMethod().Name, MethodBase.GetCurrentMethod().DeclaringType?.FullName);
                return new UserModel { error = ex.Message };
            }
        }

        [HttpPost("[action]")]
        public void Logout([FromBody]BaseModel post)
        {
            try
            {
                if (post.guid != null)
                    DAOCRM.LogoutUser(post.guid);
            }
            catch(Exception ex)
            {
                SaveErrorDB.AddError(ex, new StackTrace().GetFrame(0).GetMethod().Name, MethodBase.GetCurrentMethod().DeclaringType?.FullName);
            }
        }
    }
}