using System.IO;
using System.Text;
using System.Xml;

namespace AnalyzerRulesetGenerator
{
    public static class XmlDocumentExtensions
    {
        public static string ToIndentedString(this XmlDocument doc)
        {
            var stringWriter = new StringWriter(new StringBuilder());
            var xmlTextWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };
            doc.Save(xmlTextWriter);
            return stringWriter.ToString();
        }
    }
}