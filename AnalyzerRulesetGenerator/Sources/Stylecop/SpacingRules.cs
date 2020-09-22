using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class SpacingRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/SpacingRules.md");

        public override string SectionName { get; } = "Spacing Rules";
    }
}