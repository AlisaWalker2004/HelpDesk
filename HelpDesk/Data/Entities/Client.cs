namespace HelpDesk.Data.Entities
{
    public class Client : UserBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public string Post { get; set; }
        public int Priority { get; set; }
    }
}
