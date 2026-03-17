using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services
{
    public static class FileManager
    {
        public static void SaveToFile(Entity entity)
        {
           
            using (StreamWriter sw = new StreamWriter("data.txt", true))
            {
                sw.WriteLine(entity.GetInfo());
            }
        }
        public static void SaveToFile(Entity entity, string date)
        {
          
            using (StreamWriter sw = new StreamWriter("data.txt", true))
            {
                
                sw.WriteLine($"{entity.GetInfo()} | Date: {date}");
            }
        }
    }
}
