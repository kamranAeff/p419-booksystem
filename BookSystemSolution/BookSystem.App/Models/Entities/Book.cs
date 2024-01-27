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
    }
}
