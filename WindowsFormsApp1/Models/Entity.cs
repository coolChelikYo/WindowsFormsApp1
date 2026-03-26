using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp1.Models
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FileName { get; set; } = "data.txt";
        public static Entity Head = null;
        public Entity Next { get; set; }
        public Entity() 
        { 
        }
        public Entity(Guid id)
        {
            Id = id;
        }
        public virtual bool IsValid()
        {
            return Id != Guid.Empty;
        }
        public virtual string GetInfo()
        {
            return "ID: " + Id.ToString();
        }
        public virtual string Format()
        {
            return $"Entity|{Id}";
        }
        public virtual void SaveToFile()
        {
            File.AppendAllText(FileName, Format() + Environment.NewLine);
        }
        public void PrintToConsole()
        {
            Console.WriteLine(GetInfo());
        }
        public static string ViewList()
        {
            string info = "List of Entities:\n";
            Entity current = Head;
            while (current != null)
            {
                info += current.GetInfo() + "\n";
                current = current.Next;
            }
            return info;
        }
    }
}