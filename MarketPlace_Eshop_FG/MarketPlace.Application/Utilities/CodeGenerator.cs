using System;
using System.Text;

namespace MarketPlace.Application.Utilities
{
    public class CodeGenerator
    {
        public static string Generate(string symbol)
        {
            return $"{symbol}{RandomNumber()}";
        }

        private static string RandomString()
        {
            const int length = 2;

            var strBuild = new StringBuilder();
            var random = new Random();

            for (var i = 0; i <= length; i++)
            {
                var flt = random.NextDouble();
                var shift = Convert.ToInt32(Math.Floor(25 * flt));
                var letter = Convert.ToChar(shift + 65);
                strBuild.Append(letter);
            }

            return strBuild.ToString();
        }

        private static string RandomNumber()
        {
            var random = new Random();
            return random.Next(10000000,99999999).ToString();
        }
    }
}