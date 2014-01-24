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

            List.Add(new Algorithm("About", "About", false, "", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var assembly = Assembly.GetExecutingAssembly();

                var sb = new RtfStringBuilder();

                sb.AppendBold(string.Format("Text Inspection & Manipulation Utility vers. {0}", assembly.GetName().Version));
                sb.Append("\n\n");
                sb.Append(global::TextManipulationUtility.Properties.Resources.History);

                return sb.ToString();
            }));

            List.Add(new Algorithm("Count", "Chars, Words, Lines", false, "Text to count", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var counts = FreeFunctions.Count(input);

                return string.Format("{0} characters, {1} words, {2} lines.", counts.Item1, counts.Item2, counts.Item3);
            }));

            List.Add(new Algorithm("Count", "Alphabet", false, "Text to count", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return CountAlphabet(input, ignoreCase, reverseOutputDirection);
            }));

            List.Add(new Algorithm("Capitalisation", "Upper", false, "Text to convert to upper case", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return textInfo.ToUpper(input);
            }));

            List.Add(new Algorithm("Capitalisation", "Lower", false, "Text to convert to lower case", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return textInfo.ToLower(input);
            }));

            List.Add(new Algorithm("Capitalisation", "Title", false, "Text to convert to title case", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return textInfo.ToTitleCase(input);
            }));

            List.Add(new Algorithm("Order", "Reverse", false, "Text to reverse", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var c = input.ToCharArray();
                Array.Reverse(c);
                return new String(c);
            }));

            List.Add(new Algorithm("Order", "Reverse words", false, "Text to reverse words", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Reverse(words);
                return string.Join(" ", words);
            }));

            List.Add(new Algorithm("Order", "Reverse lines", false, "Text to reverse lines", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.None);
                Array.Reverse(lines);
                return string.Join("\n", lines);
            }));

            List.Add(new Algorithm("Order", "Scramble", false, "Text to scramble", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var c = input.ToCharArray();
                return new String(c.OrderBy(x => rnd.Next()).ToArray());
            }));

            List.Add(new Algorithm("Order", "Scramble words", false, "Text to scramble words", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(" ", words.OrderBy(x => rnd.Next()).ToArray());
            }));

            List.Add(new Algorithm("Order", "Scramble lines", false, "Text to scramble lines", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.None);
                return string.Join("\n", lines.OrderBy(x => rnd.Next()).ToArray());
            }));

            List.Add(new Algorithm("Order", "Scramble within words", false, "Text to scramble within words", "", (input, param, ignoreCase, reverseOutputDirection) =>
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

            List.Add(new Algorithm("Checksum", "MD5", false, "Text to calculate checksum", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return Md5(input);
            }));

            List.Add(new Algorithm("Checksum", "SHA-256", false, "Text to calculate checksum", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return Sha256(input);
            }));

            List.Add(new Algorithm("Checksum", "Checksum", false, "Text to calculate checksum", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var sb = new StringBuilder();

                sb.Append("MD5\t" + Md5(input) + "\n");
                sb.Append("SHA-256\t" + Sha256(input) + "\n");

                return sb.ToString();
            }));

            List.Add(new Algorithm("Sort", "Lines", false, "Text to sort", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(lines);
                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Sort", "Words", false, "Text to sort", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words);
                return string.Join(" ", reverseOutputDirection ? words.Reverse() : words);
            }));

            List.Add(new Algorithm("Search", "Simple", true, "Text to search", "Search term", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var finds = new List<int>();

                int pos = CultureInfo.CurrentCulture.CompareInfo.IndexOf(input, param, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
                while ((pos != -1) && (pos < input.Length) && !(param.Length == 0))
                {
                    finds.Add(pos);

                    pos = CultureInfo.CurrentCulture.CompareInfo.IndexOf(input, param, pos + 1, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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

            List.Add(new Algorithm("Search", "Regex", true, "Text to search", "Search regular expression", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var matches = Regex.Matches(input, param, ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);

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

            List.Add(new Algorithm("List", "Split", true, "Text to split", "Comma-separated list of separator strings", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var elements = input.Split(param.Split(new char[] { ',' }), StringSplitOptions.None);

                return string.Join("\n", reverseOutputDirection ? elements.Reverse() : elements);
            }));

            List.Add(new Algorithm("List", "Join", true, "List of text lines", "Separator to put between each joined text element", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var elements = input.Split(new char[] { '\n' });

                return string.Join(param, reverseOutputDirection ? elements.Reverse() : elements);
            }));

            List.Add(new Algorithm("List", "Append", true, "List of text lines", "Text to add at each line's end", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.None);

                for (var index = 0; index < lines.Length; ++index)
                {
                    lines[index] += param;
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("List", "Prepend", true, "List of text lines", "Text to add at each line's beginning", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.None);

                for (var index = 0; index < lines.Length; ++index)
                {
                    lines[index] = param + lines[index];
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("List", "Remove empty lines", false, "List of text lines", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Encryption", "Encrypt", true, "Text to encrypt", "Password", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return StringCipher.Encrypt(input, param);
            }));

            List.Add(new Algorithm("Encryption", "Decrypt", true, "Encrypted text to decrypt", "Password", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return StringCipher.Decrypt(input, param);
            }));

            List.Add(new Algorithm("Web", "Source", false, "A valid URL", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadString(input);
                }
            }));

            List.Add(new Algorithm("Web", "To Leet", false, "Text to convert to leet", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return Leet.ToLeet(input);
            }));

            List.Add(new Algorithm("Web", "From Leet", false, "Text to convert from leet", "", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                return Leet.FromLeet(input);
            }));

            List.Add(new Algorithm("List", "Filter", true, "List of text lines", "Filter term", (input, param, ignoreCase, reverseOutputDirection) =>
            {
                var elements = input.Split(new char[] { '\n' });
                var query = from line in elements where (CultureInfo.CurrentCulture.CompareInfo.IndexOf(line, param, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None) >= 0) select line;
                return string.Join("\n", reverseOutputDirection ? query.Reverse() : query);
            }));

        }

        private static string CountAlphabet(string input, bool caseInsensitive, bool reverseOutputDirection)
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

            return string.Join(" ", reverseOutputDirection ? dict.Reverse() : dict);
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