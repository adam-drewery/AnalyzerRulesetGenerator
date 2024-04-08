using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AnalyzerRulesetGenerator.Xml;

namespace AnalyzerRulesetGenerator.Sources
{
    public abstract class RuleSource
    {
        public abstract Uri Uri { get; }

        public abstract string AnalyzerId { get; }

        public abstract string RuleNamespace { get; }

        public abstract string SectionName { get; }

        public abstract IEnumerable<AnalyzerRule> GetRules(string document);

        public async Task<AnalyzerSettingSection> GetSection()
        {
            var section = new AnalyzerSettingSection
            {
                Name = SectionName,
                RulesetName = AnalyzerId
            };

            var doc = await (await new HttpClient().GetAsync(Uri))
                .Content.ReadAsStringAsync();

            foreach(var rule in GetRules(doc))
                section.Rules.Add(rule);

            return section;
        }
    }
}