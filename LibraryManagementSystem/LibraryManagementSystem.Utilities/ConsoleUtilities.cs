using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Utilities
{
    public class ConsoleUtilities
    {
        public static void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public static void Write(string line)
        {
            Console.Write(line);
        }

        public static void WriteInteger(int integer)
        {
            Console.WriteLine(integer);
        }

        public static void WriteNewLine()
        {
            Console.WriteLine();
        }

        public static void Clear()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine();
            }
        }
    }
}