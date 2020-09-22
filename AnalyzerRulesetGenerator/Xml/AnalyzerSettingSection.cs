using System.Collections.Generic;

namespace AnalyzerRulesetGenerator.Xml
{
    public class AnalyzerSettingSection
    {
        public string Name { get; set; }

        public string RulesetName { get; set; }

        public ICollection<AnalyzerRule> Rules { get; } = new List<AnalyzerRule>();
    }
}