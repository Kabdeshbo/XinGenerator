using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool anotherOne = new bool();
            anotherOne = true;
            while (anotherOne){
                Console.WriteLine(GenerateXin());
                Console.WriteLine("Press Esc for quit");
                Console.WriteLine("Press any key to get another");
                var key=Console.ReadKey().Key;
                Console.WriteLine();
                if (key==ConsoleKey.Escape)
                {
                    anotherOne = false;
                }
            }
        }
        static string GenerateXin()
        {
            Random rn = new Random();
            string iin = "";
            iin = DateTime.Now.ToString("yyMMdd") + rn.Next(1, 7) + rn.Next(1000, 9999);
            iin = iin + GetTwelveNumber(iin);
            return iin;
        }
        static int GetTwelveNumber(string text)
        {
            long[] array = new long[11];
            long iin = Convert.ToInt64(text);
            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = iin % 10;
                iin = iin / 10;
            }
            long razryad12 = 0;
            long[] vesRazryada = new long[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 1, 2 };
            for (int i = 0; i < array.Length; i++)
            {
                razryad12 = razryad12 + array[i] * (i + 1);
            }
            if (razryad12 % 11 == 10)
            {
                razryad12 = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    razryad12 = razryad12 + array[i] * (vesRazryada[i]);
                }
            }
            return (int)razryad12 % 11;
        }
    }
}
