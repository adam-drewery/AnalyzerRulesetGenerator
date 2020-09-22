using System.Collections.Generic;
using AnalyzerRulesetGenerator.Xml;
using HtmlAgilityPack;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public abstract class StylecopRuleSource : RuleSource
    {
        public override string AnalyzerId => "Stylecop.Analyzers";

        public override string RuleNamespace => AnalyzerId;

        public override IEnumerable<AnalyzerRule> GetRules(HtmlDocument html)
        {
            var index = 1;
            var section = new AnalyzerSettingSection();
            HtmlNodeCollection nodes;
            do
            {
                nodes = html.DocumentNode.SelectNodes($"//div[2]//article[1]//table[1]//tbody[1]//tr[{index}]//td");

                if (nodes != null)
                    yield return new AnalyzerRule
                    {
                        Id = nodes[0].InnerText,
                        Name = nodes[1].InnerText,
                        Action = "Warning",
                        Description = nodes[2].InnerText
                    };

                index++;
            }
            while (nodes != null);
        }
    }
}