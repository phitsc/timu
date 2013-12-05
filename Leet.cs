namespace TextManipulationUtility
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Leet
    {
        private static List<Tuple<string, string>> tokenDictionary = new List<Tuple<string, string>>()
        {
            new Tuple<string, string>("a", "4"),
            new Tuple<string, string>("b", "8"),
            new Tuple<string, string>("c", "("),
            new Tuple<string, string>("d", "|)"),
            new Tuple<string, string>("e", "3"),
            new Tuple<string, string>("f", "|="),
            new Tuple<string, string>("g", "6"),
            new Tuple<string, string>("h", "|-|"),
            new Tuple<string, string>("i", "!"),
            new Tuple<string, string>("j", "_|"),
            new Tuple<string, string>("k", "|<"),
            new Tuple<string, string>("l", "1"),
            new Tuple<string, string>("m", "|\\/|"),
            new Tuple<string, string>("n", "|\\|"),
            new Tuple<string, string>("o", "0"),
            new Tuple<string, string>("p", "|°"),
            new Tuple<string, string>("q", "0_"),
            new Tuple<string, string>("r", "2"),
            new Tuple<string, string>("s", "5"),
            new Tuple<string, string>("t", "7"),
            new Tuple<string, string>("u", "|_|"),
            new Tuple<string, string>("v", "\\/"),
            new Tuple<string, string>("w", "\\/\\/"),
            new Tuple<string, string>("x", "%"),
            new Tuple<string, string>("y", "`/,"),
            new Tuple<string, string>("z", "2"),
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
            var item = tokenDictionary.Find(delegate(Tuple<string, string> t) { return t.Item1 == token.ToLower(); });
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
