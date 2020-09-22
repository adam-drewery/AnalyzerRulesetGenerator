using System;
using System.Collections.Generic;
using AnalyzerRulesetGenerator.Xml;
using HtmlAgilityPack;

namespace AnalyzerRulesetGenerator.Sources
{
    public abstract class RuleSource
    {
        public abstract Uri Uri { get; }

        public abstract string AnalyzerId { get; }

        public abstract string RuleNamespace { get; }

        public abstract string SectionName { get; }

        public abstract IEnumerable<AnalyzerRule> GetRules(HtmlDocument html);

        public AnalyzerSettingSection GetSection()
        {
            var section = new AnalyzerSettingSection
            {
                Name = SectionName,
                RulesetName = AnalyzerId
            };

            var web = new HtmlWeb();
            var doc = web.Load(Uri);

            foreach(var rule in GetRules(doc))
                section.Rules.Add(rule);

            return section;
        }
    }
}