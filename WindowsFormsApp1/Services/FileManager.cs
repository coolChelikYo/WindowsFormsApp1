using System;
using System.IO;
using WindowsFormsApp1.Models;
using System.Collections.Generic;
using System.Linq;


namespace WindowsFormsApp1.Services
{
    public static class FileManager
    {
        // 1. Додаємо цей список. Саме він замінить DataManager.Entities
        public static List<IEntity> Entities = new List<IEntity>();

        public static void Add(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!entity.IsValid()) throw new Exception("Entity is invalid");

            // 2. Додаємо об'єкт у список, щоб його можна було знайти через пошук
            if (entity is IEntity iEntity)
            {
                Entities.Add(iEntity);
            }

            // Твоя логіка зі зв'язним списком (якщо вона потрібна за завданням)
            entity.Next = Entity.Head;
            Entity.Head = entity;
        }

        public static void SaveToFile(Entity entity, string date)
        {
            if (entity == null) return;

            string record = $"{entity.Format()} | Date: {date}";
            File.AppendAllText(entity.FileName, record + Environment.NewLine);
        }

        // 3. Додаємо метод пошуку, щоб MainForm могла його викликати
        public static IEnumerable<IEntity> Search(string criterion)
        {
            return Entities.Where(e => e.Search(criterion));
        }
    }
}