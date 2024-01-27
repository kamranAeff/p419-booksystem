using BookSystem.App.Extensions;
using BookSystem.App.Managers;
using BookSystem.App.Models.Entities;
using System.Collections;

namespace BookSystem.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bookManager = new Manager<Book>();
            var authorManager = new Manager<Author>();

            bookManager.Add(new Book());
            bookManager.Add(new Book());
            bookManager.Add(new Book());

            var bookForRemove = new Book(2);

            bookManager.Remove(bookForRemove);


            foreach (var item in bookManager)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
