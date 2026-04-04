using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1.Models
{
    public static class DataManager
    {
        public static IEnumerable<IEntity> Entities { get; private set; } = new List<IEntity>();

        public static void Add(IEntity entity)
        {
            Entities = Entities.Append(entity);
        }

        public static IEnumerable<IEntity> Search(string searchString)
        {
            foreach (var entity in Entities)
            {
                if (entity.Search(searchString))
                {
                    yield return entity;
                }
            }
        }
    }
}