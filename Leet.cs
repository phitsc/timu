namespace TextManipulationUtility
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Leet
    {
        private static List<Tuple<string, string>> tokenDictionary = new List<Tuple<string, string>>()
        {
            new Tuple<string, string>("A", "4"),
            new Tuple<string, string>("B", "8"),
            new Tuple<string, string>("C", "("),
            new Tuple<string, string>("D", "|)"),
            new Tuple<string, string>("E", "3"),
            new Tuple<string, string>("F", "|="),
            new Tuple<string, string>("G", "6"),
            new Tuple<string, string>("H", "|-|"),
            new Tuple<string, string>("I", "!"),
            new Tuple<string, string>("J", "_|"),
            new Tuple<string, string>("K", "|<"),
            new Tuple<string, string>("L", "1"),
            new Tuple<string, string>("M", "|\\/|"),
            new Tuple<string, string>("N", "|\\|"),
            new Tuple<string, string>("O", "0"),
            new Tuple<string, string>("P", "|°"),
            new Tuple<string, string>("Q", "0_"),
            new Tuple<string, string>("R", "2"),
            new Tuple<string, string>("S", "5"),
            new Tuple<string, string>("T", "7"),
            new Tuple<string, string>("U", "|_|"),
            new Tuple<string, string>("V", "\\/"),
            new Tuple<string, string>("W", "\\/\\/"),
            new Tuple<string, string>("X", "%"),
            new Tuple<string, string>("Y", "`/,"),
            new Tuple<string, string>("Z", "2"),
        };

        public static string ToLeet(string input)
        {
            var sb = new StringBuilder();

            foreach (var token in input)
            {
                sb.Append(TokenToLeet(token.ToString()));
            }

            return sb.ToString();
        }

        public static string FromLeet(string input)
        {
            var sb = new StringBuilder();

            while (input.Length > 0)
            { 
                bool foundToken = false;

                foreach (var token in tokenDictionary)
                {
                    if (input.StartsWith(token.Item2))
                    {
                        sb.Append(token.Item1);

                        input = input.Remove(0, token.Item2.Length);

                        foundToken = true;

                        break;
                    }
                }

                if (!foundToken)
                {
                    sb.Append(input.Substring(0, 1));

                    input = input.Remove(0, 1);
                }
            }

            return sb.ToString();
        }

        private static string TokenToLeet(string token)
        {
            var item = tokenDictionary.Find(delegate(Tuple<string, string> t) { return t.Item1 == token.ToUpper(); });
            if (item != null)
            {
                return item.Item2;
            }
            else
            {
                return token;
            }
        }
    }
}
