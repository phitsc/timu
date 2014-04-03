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

        private static char[] WordSeparators     = new char[] { ' ', '\t', '\r', '\n' };
        private static char[] LineSeparators     = new char[] { '\r', '\n' };
        private static char[] SentenceSeparators = new char[] { '.', '!', '?', '\r', '\n' };
        private static char[] WhitespaceChars    = new char[] { ' ', '\t' };

        public List<Algorithm> List { get; private set; }

        public Algorithms()
        {
            List = new List<Algorithm>();

            List.Add(new Algorithm("About", "About", string.Empty, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var assembly = Assembly.GetExecutingAssembly();

                var sb = new RtfStringBuilder();

                sb.AppendBold(string.Format("Text Inspection & Manipulation Utility vers. {0}", assembly.GetName().Version));
                sb.Append("\n\n");
                sb.Append(global::TextManipulationUtility.Properties.Resources.History);

                return sb.ToString();
            }));

            List.Add(new Algorithm("Count", "Chars, Words, Lines", "Text to count", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var counts = FreeFunctions.Count(input);

                return string.Format("{0} characters, {1} words, {2} lines.", counts.Item1, counts.Item2, counts.Item3);
            }));

            List.Add(new Algorithm("Count", "Alphabet", "Text to count", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return CountAlphabet(input, ignoreCase, reverseOutputDirection);
            }));

            List.Add(new Algorithm("Capitalisation", "Upper", "Text to convert to upper case", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return textInfo.ToUpper(input);
            }));

            List.Add(new Algorithm("Capitalisation", "Lower", "Text to convert to lower case", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return textInfo.ToLower(input);
            }));

            List.Add(new Algorithm("Capitalisation", "Title", "Text to convert to title case", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return textInfo.ToTitleCase(input);
            }));

            List.Add(new Algorithm("Capitalisation", "Sentence", "Text to convert to sentence case", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var sb = new StringBuilder();

                bool sentenceStart = true;

                foreach (var character in input)
                {
                    if (SentenceSeparators.Contains(character))
                    {
                        sb.Append(character);

                        sentenceStart = true;
                    }
                    else if (!WhitespaceChars.Contains(character) && sentenceStart)
                    {
                        sb.Append(textInfo.ToUpper(character));

                        sentenceStart = false;
                    }
                    else 
                    {
                        sb.Append(textInfo.ToLower(character));
                    }
                }

                return sb.ToString();
            }));

            List.Add(new Algorithm("Capitalisation", "Toggle", "Text to toggle case", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var sb = new StringBuilder();

                foreach (var character in input)
                {
                    sb.Append(char.IsUpper(character) ? textInfo.ToLower(character) : textInfo.ToUpper(character));
                }

                return sb.ToString();
            }));

            List.Add(new Algorithm("Order", "Reverse", "Text to reverse", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var c = input.ToCharArray();
                Array.Reverse(c);
                return new String(c);
            }));

            List.Add(new Algorithm("Order", "Reverse words", "Text to reverse words", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                string reversedInput = Reverse(input);

                return ForEachWord(reversedInput, (s) => Reverse(s));
            }));

            List.Add(new Algorithm("Order", "Reverse lines", "Text to reverse lines", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators);
                Array.Reverse(lines);
                return string.Join("\n", lines);
            }));

            List.Add(new Algorithm("Order", "Scramble", "Text to scramble", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var c = input.ToCharArray();
                return new String(c.OrderBy(x => rnd.Next()).ToArray());
            }));

            List.Add(new Algorithm("Order", "Scramble words", "Text to scramble words", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(" ", words.OrderBy(x => rnd.Next()).ToArray());
            }));

            List.Add(new Algorithm("Order", "Scramble lines", "Text to scramble lines", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators);
                return string.Join("\n", lines.OrderBy(x => rnd.Next()).ToArray());
            }));

            List.Add(new Algorithm("Order", "Scramble within words", "Text to scramble within words", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return ForEachWord(input, (s) => s.Length > 2 ? s[0] + new String(s.ToCharArray(1, s.Length - 2).OrderBy(x => rnd.Next()).ToArray()) + s[s.Length - 1] : s);
            }));

            List.Add(new Algorithm("Checksum", "MD5", "Text to calculate checksum", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return Md5(input);
            }));

            List.Add(new Algorithm("Checksum", "SHA-256", "Text to calculate checksum", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return Sha256(input);
            }));

            List.Add(new Algorithm("Checksum", "Checksum", "Text to calculate checksum", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var sb = new StringBuilder();

                sb.Append("MD5\t" + Md5(input) + "\n");
                sb.Append("SHA-256\t" + Sha256(input) + "\n");

                return sb.ToString();
            }));

            List.Add(new Algorithm("Sort", "Lines", "Text to sort", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(lines, (l, r) => string.Compare(l, r, ignoreCase));
                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Sort", "Lines (ordinal)", "Text to sort", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(lines, ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Sort", "Words", "Text to sort", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words, (l, r) => string.Compare(l, r, ignoreCase));
                return string.Join(" ", reverseOutputDirection ? words.Reverse() : words);
            }));

            List.Add(new Algorithm("Sort", "Words (ordinal)", "Text to sort", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words, ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
                return string.Join(" ", reverseOutputDirection ? words.Reverse() : words);
            }));

            List.Add(new Algorithm("Search & Replace", "Simple", "Text to search", new List<string> { "Search term" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = replaceSpecialChars(parameters[0]);

                return SearchAndReplace(input, param, null, ignoreCase);
            }));

            List.Add(new Algorithm("Search & Replace", "Replace Simple", "Text to search", 
                new List<string> 
                { 
                    "Search term",
                    "Replacement text"
                }, 
                (input, parameters, ignoreCase, reverseOutputDirection) =>
                {
                    var param0 = replaceSpecialChars(parameters[0]);
                    var param1 = replaceSpecialChars(parameters[1]);

                    return SearchAndReplace(input, param0, param1, ignoreCase);
                })
            );

            List.Add(new Algorithm("Search & Replace", "Regex", "Text to search", new List<string> { "Search regular expression" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return SearchAndReplaceRegex(input, parameters[0], null, ignoreCase);
            }));

            List.Add(new Algorithm("Search & Replace", "Replace Regex", "Text to search", 
                new List<string> 
                { 
                    "Search regular expression",
                    "Replacement text"
                },
                (input, parameters, ignoreCase, reverseOutputDirection) =>
                {
                    return SearchAndReplaceRegex(input, parameters[0], parameters[1], ignoreCase);
                })
            );

            List.Add(new Algorithm("Search & Replace", "Highlight non-ASCII characters", "Text to search for special characters", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var sb = new RtfStringBuilder();

                sb.Append(Regex.Replace(input, @"([^\u0000-\u007F])", "{{\\highlight2 $1}}", ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None));

                return sb.ToString();
            }));

            List.Add(new Algorithm("Search & Replace", "Highlight word multiplication", "Text to search for word multiplication", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var sb = new RtfStringBuilder();
                var wordSb = new StringBuilder();

                string previousWord = "";

                for (var index = 0; index < input.Length; ++index)
                {
                    if (WordSeparators.Contains(input[index]))
                    {
                        var word = wordSb.ToString();

                        if (word.Equals(previousWord, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
                        {
                            sb.AppendHighlighted(word);
                        }
                        else
                        {
                            sb.Append(word);
                        }

                        sb.Append(input[index].ToString());

                        previousWord = word;

                        wordSb.Clear();
                    }
                    else
                    {
                        wordSb.Append(input[index]);
                    }
                }

                return sb.ToString();
            }));

            /*
            List.Add(new Algorithm("Search & Replace", "Convert tabs to spaces", "Text to replace tabs with spaces", new List<string> { "Number of spaces for each tab" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = Math.Max(0, parameters[0].Length > 0 ? Convert.ToInt32(parameters[0]) : 0);
                int index = 1;

                var sb = new StringBuilder();

                foreach (var character in input)
                {
                    if (character == '\t')
                    {
                        sb.Append(new string(' ', param - (index % param)));
                    }
                    else
                    {
                        sb.Append(character);
                    }

                    ++index;
                }

                return sb.ToString();
            }));

            List.Add(new Algorithm("Search & Replace", "Convert spaces to tabs", "Text to replace spaces with tabs", new List<string> { "Number of spaces for each tab" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var result = Regex.Replace(input, new string(' ', Math.Max(0, parameters[0].Length > 0 ? Convert.ToInt32(parameters[0]) : 0)), "\t");

                return result;
            }));
            */

            List.Add(new Algorithm("Lines", "Split", "Text to split", new List<string> { "Comma-separated list of separator strings" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = replaceSpecialChars(parameters[0]);

                var elements = input.Split(param.Split(new char[] { ',' }), StringSplitOptions.None);

                return string.Join("\n", reverseOutputDirection ? elements.Reverse() : elements);
            }));

            List.Add(new Algorithm("Lines", "Join", "List of text lines", new List<string> { "Separator to put between each joined text element" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = replaceSpecialChars(parameters[0]);

                var elements = input.Split(new char[] { '\n' });

                return string.Join(param, reverseOutputDirection ? elements.Reverse() : elements);
            }));

            List.Add(new Algorithm("Lines", "Append", "List of text lines", new List<string> { "Text to add at each line's end" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = replaceSpecialChars(parameters[0]);

                var lines = input.Split(LineSeparators);

                for (var index = 0; index < lines.Length; ++index)
                {
                    lines[index] += param;
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Prepend", "List of text lines", new List<string> { "Text to add at each line's beginning" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = replaceSpecialChars(parameters[0]);

                var lines = input.Split(LineSeparators);

                for (var index = 0; index < lines.Length; ++index)
                {
                    lines[index] = param + lines[index];
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Prepend line number", "List of text lines", 
                new List<string> 
                { 
                    "Line number format string (use # for line number)" ,
                    "Start line number",
                    "Increment"
                }, 
                (input, parameters, ignoreCase, reverseOutputDirection) =>
                {
                    var param = replaceSpecialChars(parameters[0]);

                    var lines = input.Split(LineSeparators);

                    var match = Regex.Match(param, "[#]+");
                    var lineNumberFormat = match.Success ? ("d" + match.Value.Length.ToString()) : "";
                    
                    var start = 1;
                    int suppliedStart;
                    if (int.TryParse(parameters[1], out suppliedStart))
                    {
                        start = suppliedStart;
                    }

                    var increment = 1;
                    int suppliedIncrement;
                    if (int.TryParse(parameters[2], out suppliedIncrement))
                    {
                        increment = suppliedIncrement;
                    }

                    var lineNumber = start;
                    for (var index = 0; index < lines.Length; ++index)
                    {
                        var lineNumberText = lineNumberFormat.Length > 0 ? param.Replace(match.Value, lineNumber.ToString(lineNumberFormat)) : param;

                        lines[index] = lineNumberText + lines[index];
                        lineNumber += increment;
                    }

                    return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
                })
            );

            List.Add(new Algorithm("Lines", "Remove words at beginning", "List of text lines", new List<string> { "Number of words to remove at beginning of line" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators);

                var param = parameters[0].Length > 0 ? Math.Max(0, Convert.ToInt32(parameters[0])) : 0;

                if (param == 0) return input;

                for (var index = 0; index < lines.Length; ++index)
                {
                    var matches = Regex.Matches(lines[index], @"\w+");

                    lines[index] = matches.Count > param ? lines[index].Substring(matches[param].Index) : "";
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Remove words at end", "List of text lines", new List<string> { "Number of words to remove at end of line" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators);

                var param = parameters[0].Length > 0 ? Math.Max(0, Convert.ToInt32(parameters[0])) : 0;

                if (param == 0) return input;

                for (var index = 0; index < lines.Length; ++index)
                {
                    var matches = Regex.Matches(lines[index], @"\w+");

                    lines[index] = matches.Count > param ? lines[index].Substring(0, matches[matches.Count - param].Index - 1) : "";
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Keep words at beginning", "List of text lines", new List<string> { "Number of words to keep at beginning of line" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators);

                var param = parameters[0].Length > 0 ? Math.Max(0, Convert.ToInt32(parameters[0])) : 0;

                for (var index = 0; index < lines.Length; ++index)
                {
                    var matches = Regex.Matches(lines[index], @"\w+");

                    lines[index] = matches.Count > param ? lines[index].Substring(0, matches[param].Index) : lines[index];
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Keep words at end", "List of text lines", new List<string> { "Number of words to keep at end of line" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators);

                var param = parameters[0].Length > 0 ? Math.Max(0, Convert.ToInt32(parameters[0])) : 0;

                for (var index = 0; index < lines.Length; ++index)
                {
                    var matches = Regex.Matches(lines[index], @"\w+");

                    lines[index] = (param == 0)
                        ? ""
                        : matches.Count > param ? lines[index].Substring(matches[matches.Count - param].Index) : lines[index];
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Remove empty lines", "List of text lines", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Remove extra empty lines", "List of text lines", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators);
                var result = new List<string>();

                var emptyLine = false;

                foreach (var line in lines)
                {
                    if (line.Length > 0)
                    {
                        result.Add(line);
                        
                        emptyLine = false;
                    }
                    else if (!emptyLine)
                    {
                        result.Add(line);
                        emptyLine = true;
                    }
                }

                return string.Join("\n", reverseOutputDirection ? result.ToArray().Reverse() : result.ToArray());
            }));

            List.Add(new Algorithm("Lines", "Trim", "List of text lines", new List<string> { "Characters to remove on both ends" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = replaceSpecialChars(parameters[0]);

                var trimChars = param.Length > 0 ? param.ToCharArray() : WhitespaceChars;

                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (var index = 0; index < lines.Length; ++ index)
                {
                    lines[index] = lines[index].Trim(trimChars);
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Trim left", "List of text lines", new List<string> { "Characters to remove at beginning of line" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = replaceSpecialChars(parameters[0]);

                var trimChars = param.Length > 0 ? param.ToCharArray() : WhitespaceChars;

                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (var index = 0; index < lines.Length; ++index)
                {
                    lines[index] = lines[index].TrimStart(trimChars);
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Trim right", "List of text lines", new List<string> { "Characters to remove at end of line" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = replaceSpecialChars(parameters[0]);

                var trimChars = param.Length > 0 ? param.ToCharArray() : WhitespaceChars;

                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (var index = 0; index < lines.Length; ++index)
                {
                    lines[index] = lines[index].TrimEnd(trimChars);
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Delete to tag", "List of text lines", new List<string> { "Tag" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = replaceSpecialChars(parameters[0]);

                var lines = input.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (var index = 0; index < lines.Length; ++index)
                {
                    var pos = lines[index].IndexOf(param, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);

                    lines[index] = pos >= 0 ? lines[index].Substring(pos) : lines[index];
                }

                return string.Join("\n", reverseOutputDirection ? lines.Reverse() : lines);
            }));

            List.Add(new Algorithm("Lines", "Remove duplicates", "List of text lines", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var lines = input.Split(LineSeparators);
                var result = new List<string>();
                var hashSet = new HashSet<string>();

                for (var index = 0; index < lines.Length; ++index)
                {
                    if (!hashSet.Contains(ignoreCase ? lines[index].ToLower() : lines[index]))
                    {
                        result.Add(lines[index]);
                        hashSet.Add(ignoreCase ? lines[index].ToLower() : lines[index]);
                    }
                }

                return string.Join("\n", reverseOutputDirection ? result.ToArray().Reverse() : result.ToArray());
            }));

            List.Add(new Algorithm("Encryption", "Encrypt", "Text to encrypt", new List<string> { "Password" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = parameters[0];

                return StringCipher.Encrypt(input, param);
            }));

            List.Add(new Algorithm("Encryption", "Decrypt", "Encrypted text to decrypt", new List<string> { "Password" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = parameters[0];

                return StringCipher.Decrypt(input, param);
            }));

            List.Add(new Algorithm("Web", "Source", "A valid URL", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadString(input);
                }
            }));

            List.Add(new Algorithm("Web", "To Leet", "Text to convert to leet", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return Leet.ToLeet(input);
            }));

            List.Add(new Algorithm("Web", "From Leet", "Text to convert from leet", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                return Leet.FromLeet(input);
            }));

            List.Add(new Algorithm("Web", "Remove Tags", "Text to remove tags", (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var regex = new Regex(@"<[^>]*>");
                return regex.Replace(input, "");
            }));

            List.Add(new Algorithm("Lines", "Filter", "List of text lines", new List<string> { "Filter term" }, (input, parameters, ignoreCase, reverseOutputDirection) =>
            {
                var param = parameters[0];

                if (param.Length == 0) return input;

                var elements = input.Split(new char[] { '\n' });
                var query = from line in elements where (CultureInfo.CurrentCulture.CompareInfo.IndexOf(line, param, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None) >= 0) select line;

                var regex = new Regex(param, ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);
                var rtf = regex.Replace(string.Join("\n", reverseOutputDirection ? query.Reverse() : query), string.Format("{{\\highlight2 {0}}}", param));
                
                var sb = new RtfStringBuilder();
                sb.Append(rtf);

                return sb.ToString();
            }));

        }

        private static string ForEachWord(string input, Func<string, string> func)
        {
            var output = new StringBuilder();
            var word = new StringBuilder();

            for (var index = 0; index < input.Length; ++index)
            {
                if (WordSeparators.Contains(input[index]))
                {
                    output.Append(func(word.ToString()));
                    output.Append(input[index]);
                    word.Clear();
                }
                else
                {
                    word.Append(input[index]);
                }
            }

            output.Append(func(word.ToString()));

            return output.ToString();
        }

        private static string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1) 
            {
                return input;
            }

            char[] chars = input.ToCharArray();

            Array.Reverse(chars);

            return new string(chars);
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

        private static string SearchAndReplace(string input, string searchTerm, string replacementText, bool ignoreCase)
        {
            var finds = new List<int>();

            int pos = CultureInfo.CurrentCulture.CompareInfo.IndexOf(input, searchTerm, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
            while ((pos != -1) && (pos < input.Length) && !(searchTerm.Length == 0))
            {
                finds.Add(pos);

                pos = CultureInfo.CurrentCulture.CompareInfo.IndexOf(input, searchTerm, pos + 1, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
            }

            var sb = new RtfStringBuilder();

            int from = 0;
            for (int index = 0; index < finds.Count; ++index)
            {
                sb.Append(input.Substring(from, finds[index] - from));

                if (replacementText != null)
                {
                    sb.AppendHighlighted(replacementText);
                }
                else 
                {
                    sb.AppendHighlighted(input.Substring(finds[index], searchTerm.Length));
                }

                from = finds[index] + searchTerm.Length;
            }

            sb.Append(input.Substring(from));

            return sb.ToString();
        }

        private static string SearchAndReplaceRegex(string input, string searchTerm, string replacementText, bool ignoreCase)
        {
            var matches = Regex.Matches(input, searchTerm, ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);

            var sb = new RtfStringBuilder();

            int from = 0;
            foreach (Match match in matches)
            {
                sb.Append(input.Substring(from, match.Index - from));

                if (replacementText != null)
                {
                    sb.AppendHighlighted(replacementText);
                }
                else
                {
                    sb.AppendHighlighted(input.Substring(match.Index, match.Length));
                }

                from = match.Index + match.Length;
            }

            sb.Append(input.Substring(from));

            return sb.ToString();
        }

        private static string replaceSpecialChars(string input)
        {
            var sb = new StringBuilder();

            int backslashes = 0;

            foreach (var character in input)
            {
                if (character == '\\')
                {
                    ++backslashes;
                }
                else
                {
                    if (backslashes == 0)
                    {
                        sb.Append(character);
                    }
                    else if (backslashes == 1)
                    {
                        switch (character)
                        {
                            case 't': sb.Append('\t'); break;
                            case 'n': sb.Append('\n'); break;
                            default: sb.Append(character); break;
                        }
                    }
                    else
                    {
                        sb.Append(new String('\\', backslashes - 1));
                        sb.Append(character);
                    }

                    backslashes = 0;
                }
            }

            return sb.ToString();
        }
    }
}