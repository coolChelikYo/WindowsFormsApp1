using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public virtual bool IsValid()
        {
            return Id != Guid.Empty;
        }

        public virtual string GetInfo()
        {
            return "ID: " + Id.ToString();
        }
    }
}