using Logger.Models.Interfaces;
using System.Text;

namespace Logger.Models.Layouts
{
    public class XMLLayout : ILayout
    {
        public string Format => GetDataFormat();

        private string GetDataFormat()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<log>")
                .AppendLine("\t<date>{0}</date>")
                .AppendLine("\t<level>{1}</level>")
                .AppendLine("\t<message>{2}</message>")
                .AppendLine("</log>");

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
