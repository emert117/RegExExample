using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegExExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var s = "long string.....24X10  1111X22   .....1X3  X 1X X6 99X88 end";
            //var match = Regex.Match(s, @"\d+X\d+");
            //while (match.Success)
            //{
            //    Console.WriteLine($"Index: {match.Index} Length: {match.Length} Value: {match.Value}");
            //    match = match.NextMatch();
            //}

            string fieldValue = "<p>my step 2 green <img src=\"data:image/png;base64,iVBORw0KGgo\" style=\"width: 5px;\" data-filename=\"image.png\"> and"+
                                " yellow <img class=\"image-class\" src=\"data:image/png;base64,iVBORwmCC\" style=\"width: 5px;\" data-filename=\"image.png\"> inline images</p>";
            string embeddedImageHeader = "<img src=\"data:image/";
            string pattern = @"<img\s[^>]*?src\s*=\s*['\""]([^'\""]*?)['\""][^>]*?>";
            bool isMatch = Regex.IsMatch(fieldValue, pattern);
            var matches = Regex.Matches(fieldValue, pattern);
            Dictionary<int,string> markdownsForImages = new Dictionary<int, string>();
            foreach (var match in matches.ToList())
            {
                markdownsForImages.Add(match.Index, $"markdown{match.Index}");
            }
            var stringVariableMatches = Regex.Replace(fieldValue, pattern, m => markdownsForImages[m.Index]);
            
            Console.WriteLine("--end--");
        }
    }
}
