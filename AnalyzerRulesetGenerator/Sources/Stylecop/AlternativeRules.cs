using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class AlternativeRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/AlternativeRules.md");

        public override string SectionName { get; } = "Alternative Rules";
    }
}