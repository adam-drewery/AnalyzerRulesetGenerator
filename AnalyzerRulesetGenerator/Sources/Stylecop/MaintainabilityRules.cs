using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class MaintainabilityRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/MaintainabilityRules.md");

        public override string SectionName { get; } = "Maintainability Rules";
    }
}