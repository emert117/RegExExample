using System;
using System.Text.RegularExpressions;

namespace RegExExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "long string.....24X10  1111X22   .....1X3";
            var match = Regex.Match(s, @"\d+X\d+");
            if (match.Success) {
                Console.WriteLine(match.Index); // 16
                Console.WriteLine(match.Value); // 24X10;
                match = match.NextMatch();
                Console.WriteLine(match.Value);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
