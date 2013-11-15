namespace TextManipulationUtility
{
    using System;
    using System.Linq;

    internal class FreeFunctions
    {
        private static char[] WordSeparators = new char[] { ' ', '\r', '\n', '\t' };
        private static char[] LineSeparators = new char[] { '\r', '\n' };

        public static Tuple<int, int, int> Count(string input)
        {
            int characterCount = input.Count();
            int wordCount = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries).Length;
            int lineCount = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries).Length;

            return new Tuple<int, int, int>(characterCount, wordCount, lineCount);
        }
    }
}