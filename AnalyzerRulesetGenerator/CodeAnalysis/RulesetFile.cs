using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyzerRulesetGenerator.CodeAnalysis
{
    class RulesetFile
    {
        public ICollection<AnalyzerSetting> AnalyzerSettings { get; } = new List<AnalyzerSetting>();

        public string Generate()
        {
            var xml = new StringBuilder();

            xml.AppendLine(Element.Header());
            xml.AppendLine(Element.RuleSet("Rules for some project"));

            foreach (var group in AnalyzerSettings.GroupBy(x => new { x.AnalyzerId, x.RuleNamespace }))
            {
                xml.AppendLine(Element.Rules(group.Key.AnalyzerId, group.Key.RuleNamespace));

                foreach(var setting in group)
                {
                    foreach (var section in setting.Sections)
                    {
                        xml.AppendLine();
                        xml.AppendLine(Element.SectionHeader(section.Name));

                        foreach (var rule in section.Rules)
                            xml.AppendLine(Element.Rule(rule.Id, rule.Action, rule.Description));
                    }
                }

                xml.AppendLine(Element.Close(1, "Rules"));
            }

            xml.AppendLine(Element.Close(0, "RuleSet"));
            return xml.ToString();
        }
    }
}