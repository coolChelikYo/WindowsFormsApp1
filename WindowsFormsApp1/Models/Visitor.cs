using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Visitor : Person
    {
        public string TicketNumber { get; set; }

      
        public sealed override string GetInfo()
        {
            return base.GetInfo() + " | ticket: " + TicketNumber;
        }
    }
}