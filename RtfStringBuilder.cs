namespace TextManipulationUtility
{
    using System.Text;

    internal class RtfStringBuilder
    {
        private StringBuilder sb = new StringBuilder();

        public RtfStringBuilder()
        {
            sb.Append("{\\rtf1 ");
            sb.Append(@"{\colortbl;\red0\green0\blue0;\red255\green216\blue0;}");
        }

        public void Append(string s)
        {
            sb.Append(s);
        }

        public void AppendHighlighted(string s)
        {
            sb.AppendFormat("{{\\highlight2 {0}}}", s);
        }

        public void AppendBold(string s)
        {
            sb.AppendFormat("{{\\b {0}}}", s);
        }

        public override string ToString()
        {
            return sb.ToString().Replace("\n", "{{\\line}}") + "}";
        }
    }
}
