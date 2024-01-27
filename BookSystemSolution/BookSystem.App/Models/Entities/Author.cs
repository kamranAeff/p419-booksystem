namespace BookSystem.App.Models.Entities
{
    public class Author
    {
        static int counter;

        public Author()
        {
            this.Id = ++counter;
        }

        public int Id { get; private set; }
        public string FullName { get; set; }
    }
}
