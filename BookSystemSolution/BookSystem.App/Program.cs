using BookSystem.App.Extensions;

namespace BookSystem.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = Extension.ReadInt("a: ","Reqem daxil edilmelidir");

            Console.WriteLine(a);
        }
    }
}
