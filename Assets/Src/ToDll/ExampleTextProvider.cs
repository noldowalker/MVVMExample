using System;
using System.Linq;

namespace mvvm.example
{
    public class ExampleTextProvider: ITextProvider
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
        private Random random;

        public ExampleTextProvider()
        {
            random = new Random();
        }
        
        public string GenerateRandomText()
        {
            return new string(Enumerable.Repeat(chars, random.Next(300))
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}