using BookSystem.App.Models.Stables;

namespace BookSystem.App.Extensions
{
    public static partial class Extension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message">Message is Optional parameter,mean of Error Message</param>
        /// <returns></returns>
        public static int ReadInt(this string caption, string? message = null)
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Please check value";

            int value;

        l1:
            Print(caption);

            if (!int.TryParse(Console.ReadLine(), out value))
            {
                PrintLine(message, MessageType.Error);
                goto l1;
            }

            return value;
        }

        public static string ReadString(this string caption, string? message = null)
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Please check value";

            string value;

        l1:
            Print(caption);

            value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(message))
            {
                PrintLine(message, MessageType.Error);
                goto l1;
            }

            return value!;
        }
    }
}
