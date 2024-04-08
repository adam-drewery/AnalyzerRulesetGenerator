using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class AlternativeRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://raw.githubusercontent.com/DotNetAnalyzers/StyleCopAnalyzers/master/documentation/AlternativeRules.md");

        public override string SectionName { get; } = "Alternative Rules";
    }
}