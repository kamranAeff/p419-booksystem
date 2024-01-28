using BookSystem.App.Managers;
using BookSystem.App.Models.Stables;

namespace BookSystem.App.Models.Entities
{
    public class Book : IEquatable<Book>
    {
        static int counter;

        public Book()
        {
            this.Id = ++counter;
        }

        public Book(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }

        public bool Equals(Book? other)
        {
            return this.Id == other.Id;
        }

        public override string ToString()
        {
            return $"{this.Id} {this.Name} {this.PageCount} {this.Price} {this.Genre}";
        }

        //business logic wrong!!!
        //public string ToString(Manager<Author> authorManager)
        //{
        //    var author = authorManager.Find(m=>m.Id == this.AuthorId);
        //    return $"{this.Id} {this.Name} {this.PageCount} {this.Price} {this.Genre} {author?.FullName}";
        //}

        public string ToString(string authorName)
        {
            return $"{this.Id} {this.Name} {this.PageCount} {this.Price} {this.Genre} {authorName}";
        }
    }
}
