using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
   

        public sealed class Manager : Person
        {
            public string Department { get; set; }

            public override string GetInfo()
            {
                return base.GetInfo() + " | department: " + Department;
            }
        }
    }
