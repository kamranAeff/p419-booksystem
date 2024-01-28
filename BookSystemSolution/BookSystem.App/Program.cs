using BookSystem.App.Extensions;
using BookSystem.App.Managers;
using BookSystem.App.Models.Entities;
using BookSystem.App.Models.Stables;

namespace BookSystem.App
{
    internal class Program
    {
        static Manager<Book> bookManager = new Manager<Book>();
        static Manager<Author> authorManager = new Manager<Author>();

        static void Main(string[] args)
        {
            MenuOption menuOption;

        l2:
            menuOption = Extension.ChooseOption<MenuOption>("choose option: ");

        l1: switch (menuOption)
            {
                case MenuOption.BookAdd:
                    menuOption = AddNewBook();
                    goto l1;
                case MenuOption.BookEdit:
                    menuOption = BookEdit();
                    goto l1;
                case MenuOption.BookRemove:
                    menuOption = BookRemove();
                    goto l1;
                case MenuOption.BookGetById:
                    break;
                case MenuOption.BooksGetAll:
                    GetAllBooks();
                    goto l2;
                case MenuOption.AuthorAdd:
                    menuOption = AddNewAuthor();
                    goto l1;
                case MenuOption.AuthorEdit:
                    break;
                case MenuOption.AuthorRemove:
                    break;
                case MenuOption.AuthorGetById:
                    break;
                case MenuOption.AuthorsGetAll:
                    GetAllAuthors();
                    goto l2;
                case MenuOption.Save:
                    break;
                case MenuOption.Close:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void GetAllAuthors(bool allowWait = true)
        {
            Console.Clear();
            Extension.PrintLine("=== Muellifler ===");
            foreach (var item in authorManager)
            {
                Extension.PrintLine(item.ToString());
            }

            if (allowWait)
            {
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static MenuOption AddNewAuthor()
        {
            var author = new Author
            {
                FullName = Extension.ReadString("Muellifin tam adi: "),
            };

            authorManager.Add(author);

            return MenuOption.AuthorsGetAll;
        }

        private static MenuOption BookRemove()
        {
            GetAllBooks(false);

            int id;
        l1:
            id = Extension.Read<int>("siyahidan kitab idsini secin: ");

            var book = bookManager.Find(m => m.Id == id);

            if (book is null)
            {
                Extension.PrintLine("Kitab siyahidan secilmelidir", MessageType.Error);
                goto l1;
            }

            Extension.Print($"{book.Name} adli kitabi silmek isteyirsinizse <Enter> duymesini sixin...",MessageType.Error);

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                bookManager.Remove(book);
            }
            return MenuOption.BooksGetAll;
        }

        private static MenuOption BookEdit()
        {
            GetAllBooks(false);

            int id;
        l1:
            id = Extension.Read<int>("siyahidan kitab idsini secin: ");

            var book = bookManager.Find(m => m.Id == id);

            if (book is null)
            {
                Extension.PrintLine("Kitab siyahidan secilmelidir", MessageType.Error);
                goto l1;
            }

            if (authorManager.Length == 0)
            {
                Extension.PrintLine("Sistemde muellif movcud deyil", MessageType.Error);
                return MenuOption.AuthorAdd;
            }

            book.Name = Extension.ReadString("kitab yeni adi: ");
            book.Genre = Extension.ChooseOption<Genre>("kitab yeni janri: ");

        l2:
            book.PageCount = Extension.Read<int>("Kitab yeni sehife sayi");

            if (book.PageCount <= 5)
            {
                Extension.PrintLine("Sehife sayi minimum 5 olmalidir", MessageType.Error);

                goto l2;
            }

        l3:
            book.Price = Extension.Read<decimal>("Qiymet yeni qiymeti: ");

            if (book.Price <= 0)
            {
                Extension.PrintLine("Qiymet musbet olmalidir", MessageType.Error);

                goto l3;
            }

            for (int i = 0; i < authorManager.Length; i++)
            {
                Console.WriteLine(authorManager[i]);
            }

        l4:
            book.AuthorId = Extension.Read<int>("Yeni muellifin kodunu daxil et: ");

            var found = authorManager.Find(m => m.Id == book.AuthorId);

            if (found is null)
            {
                Extension.PrintLine("Muellif siyahidan secilmelidir", MessageType.Error);
                goto l4;
            }

            return MenuOption.BooksGetAll;
        }

        private static void GetAllBooks(bool allowWait = true)
        {
            Console.Clear();
            Extension.PrintLine("=== Kitablar ===");
            foreach (var item in bookManager)
            {
                var author = authorManager.Find(m => m.Id == item.AuthorId);

                Extension.PrintLine(item.ToString(author?.FullName));
            }

            if (allowWait)
            {
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static MenuOption AddNewBook()
        {
            if (authorManager.Length == 0)
            {
                Extension.PrintLine("Sistemde muellif movcud deyil", MessageType.Error);
                return MenuOption.AuthorAdd;
            }

            var book = new Book
            {
                Name = Extension.ReadString("Kitab adi: "),
                Genre = Extension.ChooseOption<Genre>("Kitab janri: "),
            };

        l1:
            book.PageCount = Extension.Read<int>("Kitab sehife sayi");

            if (book.PageCount <= 5)
            {
                Extension.PrintLine("Sehife sayi minimum 5 olmalidir", MessageType.Error);

                goto l1;
            }

        l2:
            book.Price = Extension.Read<decimal>("Qiymet");

            if (book.Price <= 0)
            {
                Extension.PrintLine("Qiymet musbet olmalidir", MessageType.Error);

                goto l2;
            }

            for (int i = 0; i < authorManager.Length; i++)
            {
                Console.WriteLine(authorManager[i]);
            }

        l3:
            book.AuthorId = Extension.Read<int>("Muellifin kodunu daxil et: ");

            var found = authorManager.Find(m => m.Id == book.AuthorId);

            if (found is null)
            {
                Extension.PrintLine("Muellif siyahidan secilmelidir", MessageType.Error);
                goto l3;
            }

            bookManager.Add(book);

            return MenuOption.BooksGetAll;
        }
    }
}
