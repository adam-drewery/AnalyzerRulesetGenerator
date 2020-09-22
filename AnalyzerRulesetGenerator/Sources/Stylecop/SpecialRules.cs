using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class SpecialRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/SpecialRules.md");

        public override string SectionName { get; } = "Special Rules";
    }
}