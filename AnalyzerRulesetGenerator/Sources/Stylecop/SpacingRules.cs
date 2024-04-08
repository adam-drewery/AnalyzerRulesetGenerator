using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class SpacingRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://raw.githubusercontent.com/DotNetAnalyzers/StyleCopAnalyzers/master/documentation/SpacingRules.md");

        public override string SectionName { get; } = "Spacing Rules";
    }
}