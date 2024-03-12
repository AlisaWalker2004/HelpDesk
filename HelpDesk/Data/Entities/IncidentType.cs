using System;

namespace HelpDesk.Data.Entities
{
    public class IncidentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan? SolutionTime { get; set; }
    }
}