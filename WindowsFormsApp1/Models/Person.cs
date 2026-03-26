using System;

namespace WindowsFormsApp1.Models
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        public new string FileName { get; set; } = "people.txt";

        public Person() : base()
        {
            Name = "Unknown";
            Email = "None";
        }

        public Person(Guid id, string name, string email) : base(id)
        {
            Name = name;
            Email = email;
        }

        public override bool IsValid()
        {
            return base.IsValid() && !string.IsNullOrEmpty(Name);
        }

        public override string GetInfo()
        {
            return base.GetInfo() + " | Name: " + Name + " | Email: " + Email;
        }

        public override string Format()
        {
            return $"Person|{Id}|{Name}|{Email}";
        }

        public virtual string GetRole()
        {
            return "Visitor";
        }

        public void UpdateEmail(string newEmail)
        {
            Email = newEmail;
        }
    }

    public sealed class Employee : Person
    {
        public string Position { get; set; }

        public Employee() : base() { }

        public Employee(Guid id, string name, string email, string position) 
            : base(id, name, email)
        {
            Position = position;
        }

        public override string GetRole()
        {
            return "Staff: " + Position;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + " | Position: " + Position;
        }
    }
}