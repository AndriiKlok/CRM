using System;
using System.IO;

namespace CRM_SYSTEM.BLL
{
    public class SaveErrorFolder
    {
        public static void AddError(string _method, string _class, string _notes)
        {
            try
            {
                using (StreamWriter sw = File.CreateText($@"D:\Logs\Error_{DateTime.Now.ToString("yyyy_MM_dd HH_mm")}.txt"))
                {
                    sw.WriteLine($"{_class} : {_method} : {_notes}");
                }
            }
            catch(Exception){ }
        }
    }
}