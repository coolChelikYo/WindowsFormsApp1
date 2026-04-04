using System;

namespace WindowsFormsApp1.Models
{
    public sealed  class Manager : Person
    {
        public string Password { get; set; }

        public Manager()
        {
            Password = string.Empty;
        }

        public Manager(Guid id, string firstName, string lastName, string email, string password)
            : base(id, firstName, lastName, email)
        {
            Password = password;
        }

        public new bool IsValid()
        {
            
            return !string.IsNullOrEmpty(Password);
        }
    }
}