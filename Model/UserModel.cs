namespace CRM_SYSTEM.Model
{
    public class UserModel : BaseModel
    {
        public int id { get; set; }
        public int type { get; set; }
        public string login { get; set; }
        public string mail { get; set; }
        public string name { get; set; }
    }
}
