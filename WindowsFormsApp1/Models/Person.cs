using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
   
        public class Person : Entity
        {
            public string Name { get; set; }
            public string Email { get; set; }

            public override bool IsValid()
            {
                return base.IsValid() && !string.IsNullOrEmpty(Name);
            }

            public override string GetInfo()
            {
                return base.GetInfo() + " | Name: " + Name;
            }
        }
    }
