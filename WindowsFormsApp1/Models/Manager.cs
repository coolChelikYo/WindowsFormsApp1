using System;

namespace WindowsFormsApp1.Models
{
    public sealed class Manager : Person
    {
        public string Department { get; set; }

        public Manager() : base()
        {
            Department = "General";
        }

        public Manager(Guid id, string name, string email, string department) 
            : base(id, name, email)
        {
            Department = department;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + " | Department: " + Department;
        }

        public override string Format()
        {
            return $"Manager|{Id}|{Name}|{Email}|{Department}";
        }

        public override string GetRole()
        {
            return "Manager of " + Department;
        }

        public void ChangeDepartment(string newDepartment)
        {
            Department = newDepartment;
        }
    }
}
