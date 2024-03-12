using System;

namespace HelpDesk.Data.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int IncidentTypeId { get; set; }
        public IncidentType Type { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CalculatedSolutionTime { get; set; }
        public bool IsSolved { get; set; }
        public DateTime? ActualSolutionTime { get; set; }
        public string Solution { get; set; }
        public int Counter { get; set; }
    }
}