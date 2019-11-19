
using System;

namespace CRM_SYSTEM.Model
{
    public class TaskModel : BaseModel
    {
        public int nid { get; set; }
        public string sid { get; set; }
        public int ntype { get; set; }
        public string stype { get; set; }
        public int nstate { get; set; }
        public string sstate { get; set; }
        public int usrCreate { get; set; }
        public string usrCreateName { get; set; }
        public int usrRealize { get; set; }
        public string usrRealizeName { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string description { get; set; }
        public DateTime? dateCreate { get; set; }
        public DateTime? dateRealize { get; set; }
    }
}
