namespace BookSystem.App.Models.Stables
{
    public enum MenuOption : byte
    {
        BookAdd = 1,
        BookEdit,
        BookRemove,
        BookGetById,
        BooksGetAll,

        AuthorAdd,
        AuthorEdit,
        AuthorRemove,
        AuthorGetById,
        AuthorsGetAll,

        Save,
        Close
    }
}
