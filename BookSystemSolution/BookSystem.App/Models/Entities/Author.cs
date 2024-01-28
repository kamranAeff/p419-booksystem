namespace BookSystem.App.Models.Entities
{
    public class Author : IEquatable<Author>
    {
        static int counter;

        public Author()
        {
            this.Id = ++counter;
        }
        public Author(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
        public string FullName { get; set; }

        public bool Equals(Author? other)
        {
            return this.Id == other.Id;
        }

        public override string ToString()
        {
            return $"{this.Id}. {this.FullName}";
        }
    }
}
