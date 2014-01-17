namespace TextManipulationUtility
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Algorithms
    {
        private TextInfo textInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
        private Random rnd = new Random();

        private char[] WordSeparators = new char[] { ' ', '\r', '\n' };
        private char[] LineSeparators = new char[] { '\r', '\n' };

        public List<Algorithm> List { get; private set; }

        public Algorithms()
        {
            List = new List<Algorithm>();

            List.Add(new Algorithm("About", "About", false, "", "", (input, param) =>
            {
                var assembly = Assembly.GetExecutingAssembly();

                var sb = new RtfStringBuilder();

                sb.AppendBold(string.Format("Text Inspection & Manipulation Utility vers. {0}", assembly.GetName().Version));
                sb.Append("\n\n");
                sb.Append(global::TextManipulationUtility.Properties.Resources.History);

                return sb.ToString();
            }));

            List.Add(new Algorithm("Count", "Chars, Words, Lines", false, "", "", (input, param) =>
            {
                var counts = FreeFunctions.Count(input);

                return string.Format("{0} characters, {1} words, {2} lines.", counts.Item1, counts.Item2, counts.Item3);
            }));

            List.Add(new Algorithm("Count", "Alphabet", false, "", "", (input, param) =>
            {
                return CountAlphabet(input, false);
            }));

            List.Add(new Algorithm("Count", "Alphabet case-insensitive", false, "", "", (input, param) =>
            {
                return CountAlphabet(input, true);
            }));

            List.Add(new Algorithm("Capitalisation", "Upper", false, "", "", (input, param) =>
            {
                return textInfo.ToUpper(input);
            }));

            List.Add(new Algorithm("Capitalisation", "Lower", false, "", "", (input, param) =>
            {
                return textInfo.ToLower(input);
            }));

            List.Add(new Algorithm("Capitalisation", "Title", false, "", "", (input, param) =>
            {
                return textInfo.ToTitleCase(input);
            }));

            List.Add(new Algorithm("Order", "Reverse", false, "", "", (input, param) =>
            {
                var c = input.ToCharArray();
                Array.Reverse(c);
                return new String(c);
            }));

            List.Add(new Algorithm("Order", "Reverse words", false, "", "", (input, param) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Reverse(words);
                return string.Join(" ", words);
            }));

            List.Add(new Algorithm("Order", "Scramble", false, "", "", (input, param) =>
            {
                var c = input.ToCharArray();
                return new String(c.OrderBy(x => rnd.Next()).ToArray());
            }));

            List.Add(new Algorithm("Order", "Scramble words", false, "", "", (input, param) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(" ", words.OrderBy(x => rnd.Next()).ToArray());
            }));

            List.Add(new Algorithm("Order", "Scramble within words", false, "", "", (input, param) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (var index = 0; index < words.Length; ++index)
                {
                    var word = words[index];

                    if (word.Length > 2)
                    {
                        var chars = word.ToCharArray(1, word.Length - 2);
                        words[index] = word[0] + new String(chars.OrderBy(x => rnd.Next()).ToArray()) + word[word.Length - 1];
                    }
                }

                return string.Join(" ", words);
            }));

            List.Add(new Algorithm("Checksum", "MD5", false, "", "", (input, param) =>
            {
                return Md5(input);
            }));

            List.Add(new Algorithm("Checksum", "SHA-256", false, "", "", (input, param) =>
            {
                return Sha256(input);
            }));

            List.Add(new Algorithm("Checksum", "Checksum", false, "", "", (input, param) =>
            {
                var sb = new StringBuilder();

                sb.Append("MD5\t" + Md5(input) + "\n");
                sb.Append("SHA-256\t" + Sha256(input) + "\n");

                return sb.ToString();
            }));

            List.Add(new Algorithm("Sort", "Lines A-Z", false, "", "", (input, param) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(lines);
                return string.Join("\n", lines);
            }));

            List.Add(new Algorithm("Sort", "Lines Z-A", false, "", "", (input, param) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(lines);
                Array.Reverse(lines);
                return string.Join("\n", lines);
            }));

            List.Add(new Algorithm("Sort", "Words A-Z", false, "", "", (input, param) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words);
                return string.Join(" ", words);
            }));

            List.Add(new Algorithm("Sort", "Words Z-A", false, "", "", (input, param) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words);
                Array.Reverse(words);
                return string.Join(" ", words);
            }));

            List.Add(new Algorithm("Search", "Simple", true, "", "", (input, param) =>
            {
                var finds = new List<int>();

                int pos = input.IndexOf(param);
                while ((pos != -1) && (pos < input.Length) && !(param.Length == 0))
                {
                    finds.Add(pos);

                    pos = input.IndexOf(param, pos + 1);
                }

                var sb = new RtfStringBuilder();

                int from = 0;
                for (int index = 0; index < finds.Count; ++index)
                {
                    sb.Append(input.Substring(from, finds[index] - from));
                    sb.AppendHighlighted(input.Substring(finds[index], param.Length));

                    from = finds[index] + param.Length;
                }

                sb.Append(input.Substring(from));

                return sb.ToString();
            }));

            List.Add(new Algorithm("Search", "Regex", true, "", "", (input, param) =>
            {
                var matches = Regex.Matches(input, param);

                var sb = new RtfStringBuilder();

                int from = 0;
                foreach (Match match in matches)
                {
                    sb.Append(input.Substring(from, match.Index - from));
                    sb.AppendHighlighted(input.Substring(match.Index, match.Length));

                    from = match.Index + match.Length;
                }

                sb.Append(input.Substring(from));

                return sb.ToString();
            }));

            List.Add(new Algorithm("List", "Split", true, "", "Comma-separated list of separator strings", (input, param) =>
            {
                var elements = input.Split(param.Split(new char[] { ',' }), StringSplitOptions.None);

                return string.Join("\n", elements);
            }));

            List.Add(new Algorithm("List", "Join", false, "", "", (input, param) =>
            {
                var elements = input.Split(new char[] { '\n' });

                return string.Join(param, elements);
            }));

            List.Add(new Algorithm("List", "Append", true, "", "Text to add at each line's end", (input, param) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (var index = 0; index < lines.Length; ++index)
                {
                    lines[index] += param;
                }

                return string.Join("\n", lines);
            }));

            List.Add(new Algorithm("List", "Prepend", true, "", "Text to add at each line's beginning", (input, param) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (var index = 0; index < lines.Length; ++index)
                {
                    lines[index] = param + lines[index];
                }

                return string.Join("\n", lines);
            }));

            List.Add(new Algorithm("List", "Remove empty lines", false, "", "", (input, param) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

                return string.Join("\n", lines);
            }));

            List.Add(new Algorithm("Encryption", "Encrypt", true, "", "Password", (input, param) =>
            {
                return StringCipher.Encrypt(input, param);
            }));

            List.Add(new Algorithm("Encryption", "Decrypt", true, "", "Password", (input, param) =>
            {
                return StringCipher.Decrypt(input, param);
            }));

            List.Add(new Algorithm("Web", "Source", false, "A valid URL", "", (input, param) =>
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadString(input);
                }
            }));

            List.Add(new Algorithm("Web", "To Leet", false, "", "", (input, param) =>
            {
                return Leet.ToLeet(input);
            }));

            List.Add(new Algorithm("Web", "From Leet", false, "", "", (input, param) =>
            {
                return Leet.FromLeet(input);
            }));

            List.Add(new Algorithm("List", "Filter", true, "", "", (i, p) =>
            {
                var elements = i.Split(new char[] { '\n' });
                var query = from line in elements where line.Contains(p) select line;
                return string.Join("\n", query);
            }));

        }

        private static string CountAlphabet(string input, bool caseInsensitive)
        {
            var dict = new SortedDictionary<char, int>();

            foreach (var character in input)
            {
                if (char.IsLetter(character))
                {
                    var letter = caseInsensitive ? char.ToLower(character) : character;

                    if (dict.ContainsKey(letter))
                    {
                        dict[letter]++;
                    }
                    else
                    {
                        dict.Add(letter, 1);
                    }
                }
            }

            return string.Join(" ", dict);
        }

        private static string FormatHash(byte[] hash)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        private static string Md5(string input)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                return FormatHash(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input)));
            }
        }

        private static string Sha256(string input)
        {
            using (var hasher = new System.Security.Cryptography.SHA256Managed())
            {
                return FormatHash(hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input)));
            }
        }
    }
}