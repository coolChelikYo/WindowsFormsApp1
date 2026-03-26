using System;

namespace WindowsFormsApp1.Models
{
    public class Visitor : Person
    {
        public string TicketNumber { get; set; }

        public Visitor() : base()
        {
            TicketNumber = "000-000";
        }

        public Visitor(Guid id, string name, string email, string ticketNumber) 
            : base(id, name, email)
        {
            TicketNumber = ticketNumber;
        }

        public sealed override string GetInfo()
        {
            return base.GetInfo() + " | Ticket: " + TicketNumber;
        }

        public override string Format()
        {
            return $"Visitor|{Id}|{Name}|{Email}|{TicketNumber}";
        }

        public override string GetRole()
        {
            return "Active Visitor";
        }

        public bool HasTicket()
        {
            return !string.IsNullOrEmpty(TicketNumber);
        }
    }
}