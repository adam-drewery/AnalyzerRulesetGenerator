using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AnalyzerRulesetGenerator.CodeAnalysis;

namespace AnalyzerRulesetGenerator.Sources
{
    public abstract class RuleSource
    {
        private HttpClient _http = new HttpClient();
        
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

            _http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.114 Safari/537.36");
            
            var doc = await (await _http.GetAsync(Uri))
                .Content.ReadAsStringAsync();

            foreach(var rule in GetRules(doc))
                section.Rules.Add(rule);

            return section;
        }
    }
}