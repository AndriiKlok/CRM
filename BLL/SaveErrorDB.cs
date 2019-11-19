using CRM_SYSTEM.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CRM_SYSTEM.BLL
{
    public class SaveErrorDB
    {
        public static void AddError(Exception ex, string _method, string _class)
        {
            string line = "";
            StackTrace st = new StackTrace(ex, true);
            if (st.FrameCount > 0) line = $" (line {st.GetFrame(st.FrameCount - 1).GetFileLineNumber()})";

            DAOCRM.AddError(_method, _class, line + ex.Message);
        }
    }
}