using System.Collections.Generic;

namespace AnalyzerRulesetGenerator.CodeAnalysis
{
    class AnalyzerSetting
    {
        public string AnalyzerId { get; set; }

        public string RuleNamespace { get; set; }

        public ICollection<AnalyzerSettingSection> Sections { get; } = new List<AnalyzerSettingSection>();
    }
}