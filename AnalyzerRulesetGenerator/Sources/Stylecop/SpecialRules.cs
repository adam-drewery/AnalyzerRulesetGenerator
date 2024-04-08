using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class SpecialRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://raw.githubusercontent.com/DotNetAnalyzers/StyleCopAnalyzers/master/documentation/SpecialRules.md");

        public override string SectionName { get; } = "Special Rules";
    }
}