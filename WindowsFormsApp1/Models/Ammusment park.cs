using System;
using System.Collections.Generic;
using System.Linq;  

namespace WindowsFormsApp1.Models
{
    public class AmusementPark : Entity, IEntity
    {
        public override string FileName => "AmusementPark.txt";

        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public DateTime? StartDateTime { get; set; }  
        public List<string> Attractions { get; set; }
        public List<Visitor> Visitors { get; set; }

        public AmusementPark()
        {
            Name = string.Empty;
            Description = string.Empty;
            Duration = null;
            StartDateTime = DateTime.Now;
            Attractions = new List<string>();
            Visitors = new List<Visitor>();
        }

        public AmusementPark(Guid id, string name, string description, TimeSpan? duration, DateTime? startDateTime, List<string> attractions, List<Visitor> visitors)
            : base(id)
        {
            Name = name;
            Description = description;
            Duration = duration;
            StartDateTime = startDateTime ?? DateTime.Now;
            Attractions = attractions ?? new List<string>();
            Visitors = visitors ?? new List<Visitor>();
        }

        public override string Format()
        {
            var visitorsIdStr = Visitors != null
                ? string.Join(",", Visitors.Select(v => v.Id.ToString()))
                : string.Empty;

            return $"{base.Format()}[{Name}][{Description}][{Duration}][{StartDateTime:dd/MM/yyyy HH:mm}][{visitorsIdStr}]";
        }
 
        public override bool Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return false;
 
            bool nameMatch = Name != null && Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0;
            bool descMatch = Description != null && Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0;

            return nameMatch || descMatch;
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) &&
                   Duration != null &&
                   StartDateTime != null;
        }
    }
}