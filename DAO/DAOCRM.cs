using CRM_SYSTEM.BLL;
using System;
using System.Data;

namespace CRM_SYSTEM.DAO
{
    static class DAOCRM
    {
        static public void AddError(string _method, string _class, string _notes)
        {
            try
            {
                DataBaseAccess access = new DataBaseAccess();

                access.LoadProcedure("WEB.AddError");
                access.AddParameter("@class", _class);
                access.AddParameter("@method", _method);
                access.AddParameter("@notes", _notes);

                access.ExecuteProcedure();
            }
            catch (Exception)
            {
                SaveErrorFolder.AddError(_method, _class, _notes);
            }
        }

        static public DataTable LoginUser(string Login, string Password, string GUID)
        {
            try
            {
                DataBaseAccess access = new DataBaseAccess();

                access.LoadProcedure("WEB.LoginUser");
                access.AddParameter("@Login", Login);
                access.AddParameter("@Password", Password);
                access.AddParameter("@GUID", GUID);


                return access.ExecuteProcedure();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public DataTable LoginedUser(string GUID)
        {
            try
            {
                DataBaseAccess access = new DataBaseAccess();

                access.LoadProcedure("WEB.LoginedUser");
                access.AddParameter("@GUID", GUID);


                return access.ExecuteProcedure();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        static public void LogoutUser(string GUID)
        {
            try
            {
                DataBaseAccess access = new DataBaseAccess();

                access.LoadProcedure("WEB.LogoutUser");
                access.AddParameter("@GUID", GUID);


                access.ExecuteProcedure();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public DataTable AddTask(string GUID, int? UsrRealize, string Title, string Content, string Description)
        {
            try
            {
                DataBaseAccess access = new DataBaseAccess();

                access.LoadProcedure("WEB.AddTask");
                access.AddParameter("@GUID", GUID);
                access.AddParameter("@UsrRealize", UsrRealize);
                access.AddParameter("@Title", Title);
                access.AddParameter("@Content", Content);
                access.AddParameter("@Description", Description);

                return access.ExecuteProcedure();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public DataTable ClientTasksList(string GUID)
        {
            try
            {
                DataBaseAccess access = new DataBaseAccess();

                access.LoadProcedure("WEB.ClientTasksList");
                access.AddParameter("@GUID", GUID);

                return access.ExecuteProcedure();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}
