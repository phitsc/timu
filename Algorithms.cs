
namespace TextManipulationUtility
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;

    class Algorithms
    {
        private TextInfo textInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo;

        public List<Algorithm> algorithms { get; private set; }

        public Algorithms()
        {
            algorithms = new List<Algorithm>();

            algorithms.Add(new Algorithm("Count", "Chars, Words, Lines", input =>
            {
                int characterCount = input.Count();
                int wordCount = input.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
                int lineCount = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

                return String.Format("{0} characters. {1} words. {2} lines.", characterCount, wordCount, lineCount);
            }));

            algorithms.Add(new Algorithm("Count", "Alphabet", input =>
            {
                return countAlphabet(input, false);
            }));

            algorithms.Add(new Algorithm("Count", "case-insensitive", input =>
            {
                return countAlphabet(input, true);
            }));

            algorithms.Add(new Algorithm("Capitalisation", "Upper", input =>
            {
                return textInfo.ToUpper(input);
            }));

            algorithms.Add(new Algorithm("Capitalisation", "Lower", input =>
            {
                return textInfo.ToLower(input);
            }));

            algorithms.Add(new Algorithm("Capitalisation", "Camel", input =>
            {
                return textInfo.ToTitleCase(input);
            }));

            algorithms.Add(new Algorithm("Order", "Reverse", input =>
            {
                var c = input.ToCharArray();
                Array.Reverse(c);
                return new String(c);
            }));

            algorithms.Add(new Algorithm("Order", "Scramble", input =>
            {
                var c = input.ToCharArray();
                var rnd = new Random();
                return new String(c.OrderBy(x => rnd.Next()).ToArray());
            }));

            algorithms.Add(new Algorithm("Checksum", "MD5", input =>
            {
                return md5(input);
            }));

            algorithms.Add(new Algorithm("Checksum", "SHA-256", input =>
            {
                return sha256(input);
            }));

            algorithms.Add(new Algorithm("Checksum", "Checksum", input =>
            {
                var sb = new StringBuilder();

                sb.Append("MD5\t" + md5(input) + "\n");
                sb.Append("SHA-256\t" + sha256(input) + "\n");

                return sb.ToString();
            }));

            algorithms.Add(new Algorithm("Sort", "A-Z", input =>
            {
                var words = input.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words);
                return string.Join(" ", words);
            }));

            algorithms.Add(new Algorithm("Sort", "Z-A", input =>
            {
                var words = input.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words);
                Array.Reverse(words);
                return string.Join(" ", words);
            }));

            algorithms.Add(new Algorithm("Web", "Source", input =>
            {
                using (var webClient = new WebClient())
                {
                    try
                    {
                        return webClient.DownloadString(input);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }));
        }

        private string countAlphabet(string input, bool caseInsensitive)
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

        private string formatHash(byte[] hash)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        string md5(string input)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                return formatHash(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input)));
            }
        }

        string sha256(string input)
        {
            using (var hasher = new System.Security.Cryptography.SHA256Managed())
            {
                return formatHash(hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input)));
            }
        }
    }
}