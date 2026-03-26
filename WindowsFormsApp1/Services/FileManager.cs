using System;
using System.IO;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services
{
    public static class FileManager
    {
        public static void Add(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!entity.IsValid()) throw new Exception("Entity is invalid");

            entity.Next = Entity.Head;
            Entity.Head = entity;

           // string record = entity.Format();
           // File.AppendAllText(entity.FileName, record + Environment.NewLine);
        }

        public static void SaveToFile(Entity entity, string date)
        {
            if (entity == null) return;
            
            string record = $"{entity.Format()} | Date: {date}";
            File.AppendAllText(entity.FileName, record + Environment.NewLine);
        }
    }
}