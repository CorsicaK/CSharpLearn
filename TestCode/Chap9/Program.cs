using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Chap9
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 23, 52);
            Vector v2 = new Vector(56.232, -562.1, 55);
            Console.WriteLine("IJK: {0,30:IJK}    {1,30:IJK}", v1,v2);
            Console.WriteLine("VE: {0,30:VE}    {1,30:VE}", v1, v2);
            Console.WriteLine("N: {0,30:N}    {1,30:N}", v1, v2);

            Find2();

            Console.ReadKey();
        }

        #region 正则表达式示例
        static void WriteMatches(string text, MatchCollection matches)
        {
            Console.WriteLine("Original text was:\n\n" + text + "\n");

            Console.WriteLine("No.of matches:" + matches.Count);

            foreach (Match nextMatch in matches)
            {
                int index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;

                Console.WriteLine("Index:{0},\tString:{1},\t{2}", index, result, text.Substring(index - charsBefore, charsToDisplay));
            }
        }

        static void Find2()
        {
            string text = @"This comprehensive compendium provides a broad and thorough 
investigation of all aspects of programming with ASP .NET. Entirely revised and
updated for the 3.5 Release of .NET， this book will give you the informat ion
you need to master ASP.NET and build a dynamic, successful, enterprise Web
application.";
            string pattern = @"\ba";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
            WriteMatches(text, matches);
        }

        #endregion
    }
}
