using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class ReadabilityRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://raw.githubusercontent.com/DotNetAnalyzers/StyleCopAnalyzers/master/documentation/ReadabilityRules.md");

        public override string SectionName { get; } = "Readability Rules";
    }
}