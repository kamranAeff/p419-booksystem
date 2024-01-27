using BookSystem.App.Models.Entities;
using System.Collections;

namespace BookSystem.App.Managers
{
    public class Manager<T> : IManager<T>
        where T : class
    {
        T[] entities = new T[0];

        public void Add(T entity)
        {
            int len = entities.Length;
            Array.Resize(ref entities, len + 1);
            entities[len] = entity;
        }

        public void Remove(T entity)
        {
#warning uncompleted 
            int index = Array.IndexOf(entities, entity);
            if (index <= -1)
                return;

            for (int i = index; i < entities.Length - 1; i++)
            {
                entities[i]= entities[i + 1];
            }


            Array.Resize(ref entities, entities.Length - 1);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < entities.Length; i++)
            {
                yield return entities[i];
            }
        }
    }
}
