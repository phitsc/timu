namespace TextManipulationUtility
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private TextInfo textInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo;

        public MainForm()
        {
            InitializeComponent();

            PopulateManipulations();

            inputTextBox.Text = Clipboard.GetText();
        }

        void PopulateManipulations()
        {
            var count = manipulationsTreeView.Nodes.Add("Count");
            count.Nodes.Add("Chars, Words, Lines");
            count.Nodes.Add("Alphabet");
            count.Nodes.Add("Alphabet case-insensitive");

            var caps = manipulationsTreeView.Nodes.Add("Capitalisation");
            caps.Nodes.Add("Upper");
            caps.Nodes.Add("Lower");
            caps.Nodes.Add("Camel");

            var order = manipulationsTreeView.Nodes.Add("Order");
            order.Nodes.Add("Reverse");
            order.Nodes.Add("Scramble");

            var checksums = manipulationsTreeView.Nodes.Add("Checksums");
            checksums.Nodes.Add("MD5");
            checksums.Nodes.Add("SHA-256");

            var sort = manipulationsTreeView.Nodes.Add("Sort");
            sort.Nodes.Add("A-Z");
            sort.Nodes.Add("Z-A");

            var web = manipulationsTreeView.Nodes.Add("Web");
            web.Nodes.Add("Source");
            //web.Nodes.Add("Render");
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            updateOutput();
        }

        private void manipulationsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            updateOutput();
        }

        private void updateOutput()
        {
            switch (manipulationsTreeView.SelectedNode.Text)
            {
                case "Count":
                case "Chars, Words, Lines":
                    outputTextBox.Text = count(inputTextBox.Text);
                    break;

                case "Alphabet":
                    outputTextBox.Text = countAlphabet(inputTextBox.Text, false);
                    break;

                case "Alphabet case-insensitive":
                    outputTextBox.Text = countAlphabet(inputTextBox.Text, true);
                    break;

                case "Capitalisation":
                case "Upper":
                    outputTextBox.Text = upper(inputTextBox.Text);
                    break;

                case "Lower":
                    outputTextBox.Text = lower(inputTextBox.Text);
                    break;

                case "Camel":
                    outputTextBox.Text = camel(inputTextBox.Text);
                    break;

                case "Order":
                case "Reverse":
                    outputTextBox.Text = reverse(inputTextBox.Text);
                    break;

                case "Scramble":
                    outputTextBox.Text = scramble(inputTextBox.Text);
                    break;

                case "Checksums":
                    outputTextBox.Text = checksums(inputTextBox.Text);
                    break;

                case "MD5":
                    outputTextBox.Text = md5(inputTextBox.Text);
                    break;

                case "SHA-256":
                    outputTextBox.Text = sha256(inputTextBox.Text);
                    break;

                case "Sort":
                case "A-Z":
                    outputTextBox.Text = sortAZ(inputTextBox.Text);
                    break;

                case "Z-A":
                    outputTextBox.Text = sortZA(inputTextBox.Text);
                    break;

                case "Web":
                case "Source":
                    outputTextBox.Text = webSource(inputTextBox.Text);
                    break;

                case "Render":
                    outputTextBox.Text = webRender(inputTextBox.Text);
                    break;
            }
        }

        private string count(string input)
        {
            int characterCount = input.Count();
            int wordCount = input.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int lineCount = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

            return String.Format("{0} characters. {1} words. {2} lines.", characterCount, wordCount, lineCount);
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

        private string upper(string input)
        {
            return textInfo.ToUpper(input);
        }

        private string lower(string input)
        {
            return textInfo.ToLower(input);
        }

        private string camel(string input)
        {
            return textInfo.ToTitleCase(input);
        }

        private string reverse(string input)
        {
            var c = input.ToCharArray();
            Array.Reverse(c);
            return new String(c);
        }

        private string scramble(string input)
        {
            var c = input.ToCharArray();
            var rnd = new Random();
            return new String(c.OrderBy(x => rnd.Next()).ToArray());
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

        private string md5(string input)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                return formatHash(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input)));
            }
        }

        private string sha256(string input)
        {
            using (var hasher = new System.Security.Cryptography.SHA256Managed())
            {
                return formatHash(hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input)));
            }
        }

        private string checksums(string input)
        {
            var sb = new StringBuilder();

            sb.Append("MD5\t" + md5(input) + "\n");
            sb.Append("SHA-256\t" + sha256(input) + "\n");

            return sb.ToString();
        }

        private string sortAZ(string input)
        {
            var words = input.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            return string.Join(" ", words);
        }

        private string sortZA(string input)
        {
            var words = input.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        private string webSource(string input)
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
        }

        private string webRender(string input)
        {
            string result;

            var source = webSource(input);

            // Remove HTML Development formatting
            // Replace line breaks with space
            // because browsers inserts space
            result = source.Replace("\r", " ");
            // Replace line breaks with space
            // because browsers inserts space
            result = result.Replace("\n", " ");
            // Remove step-formatting
            result = result.Replace("\t", string.Empty);
            // Remove repeating speces becuase browsers ignore them
            result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                  @"( )+", " ");

            // Remove the header (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*head([^>])*>", "<head>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*head( )*>)", "</head>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(<head>).*(</head>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // remove all scripts (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*script([^>])*>", "<script>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*script( )*>)", "</script>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //result = System.Text.RegularExpressions.Regex.Replace(result, 
            //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            //         string.Empty, 
            //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<script>).*(</script>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // remove all styles (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*style([^>])*>", "<style>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*style( )*>)", "</style>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(<style>).*(</style>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert tabs in spaces of <td> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*td([^>])*>", "\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert line breaks in places of <BR> and <LI> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*br( )*>", "\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*li( )*>", "\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert line paragraphs (double line breaks) in place
            // if <P>, <DIV> and <TR> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*div([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*tr([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*p([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // Remove remaining tags like <a>, links, images,
            // comments etc - anything thats enclosed inside < >
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<[^>]*>", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // replace special characters:
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&nbsp;", " ",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&bull;", " * ",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&lsaquo;", "<",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&rsaquo;", ">",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&trade;", "(tm)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&frasl;", "/",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<", "<",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @">", ">",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&copy;", "(c)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&reg;", "(r)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove all others. More can be added, see
            // http://hotwired.lycos.com/webmonkey/reference/special_characters/
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&(.{2,6});", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);


            // make line breaking consistent
            result = result.Replace("\n", "\r");

            // Remove extra line breaks and tabs:
            // replace over 2 breaks with 2 and over 4 tabs with 4. 
            // Prepare first to remove any whitespaces inbetween
            // the escaped characters and remove redundant tabs inbetween linebreaks
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)( )+(\r)", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\t)( )+(\t)", "\t\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\t)( )+(\r)", "\t\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)( )+(\t)", "\r\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove redundant tabs
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)(\t)+(\r)", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove multible tabs followind a linebreak with just one tab
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)(\t)+", "\r\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Initial replacement target string for linebreaks
            string breaks = "\r\r\r";
            // Initial replacement target string for tabs
            string tabs = "\t\t\t\t\t";
            for (int index = 0; index < result.Length; index++)
            {
                result = result.Replace(breaks, "\r\r");
                result = result.Replace(tabs, "\t\t\t\t");
                breaks = breaks + "\r";
                tabs = tabs + "\t";
            }

            // Thats it.
            return result;
        }
    }
}
