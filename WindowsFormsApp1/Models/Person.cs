using System;

namespace WindowsFormsApp1.Models
{
     
    public class Person : Entity,IEntity 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Person()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }

        public Person(Guid id, string firstName, string lastName, string email) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public new bool IsValid()
        {
            return base.IsValid() &&
                   !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(LastName) &&
                   !string.IsNullOrEmpty(Email);
        }
        public override bool Search(string searchString)
{
    if (string.IsNullOrEmpty(searchString)) return false;

    string search = searchString.ToLower();

    return (FirstName != null && FirstName.ToLower().Contains(search)) || 
           (LastName != null && LastName.ToLower().Contains(search)) || 
           (Email != null && Email.ToLower().Contains(search));
}
        public override string Format()
{
    return $"{base.Format()}[{FirstName}][{LastName}][{Email}]";
}
    }
}