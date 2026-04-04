using System;

namespace WindowsFormsApp1.Models
{
    public class Visitor : Person
    {
        public string PhoneNumber { get; set; }

        public Visitor()
        {
            PhoneNumber = string.Empty;
        }

        public Visitor(Guid id, string firstName, string lastName, string email, string phoneNumber)
            : base(id, firstName, lastName, email)
        {
            PhoneNumber = phoneNumber;
        }

        public new bool IsValid()
        {
            return base.IsValid() && !string.IsNullOrEmpty(PhoneNumber);
        }

        public override sealed string Format()
        {
            return $"[{base.Format()}][{PhoneNumber}]";
        }
    }
}