using BookSystem.App.Models.Stables;
using System.Threading;

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
        public static T Read<T>(this string caption, string? message = null)
            where T : struct
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Please check value";

        l1:
            Print(caption);

            try
            {
                return (T)(Convert.ChangeType(Console.ReadLine(), typeof(T)) ?? default)!;
            }
            catch (Exception)
            {
                PrintLine(message, MessageType.Error);
                goto l1;
            }
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

        public static T ChooseOption<T>(this string caption, string? message = null)
            where T : Enum
        {
            if (string.IsNullOrWhiteSpace(message))
                message = "Option must be choose from list";

            Type type = typeof(T);
            Type uType = Enum.GetUnderlyingType(type);

            var backupColor = Console.ForegroundColor;
            Console.WriteLine("===============CHOOSE OPTION==============");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in Enum.GetValues(type))
            {
                var orderNo = Convert.ChangeType(item, uType);

                Console.WriteLine($"{orderNo}. {item}");
            }
            Console.ForegroundColor = backupColor;
            Console.WriteLine("==========================================");

        l1:
            Print(caption);
            if (!Enum.TryParse(type,Console.ReadLine(), true, out object enumValue) || !Enum.IsDefined(type, enumValue))
            {
                PrintLine(message, MessageType.Error);
                goto l1;
            }

            return (T)enumValue;
        }
    }
}
