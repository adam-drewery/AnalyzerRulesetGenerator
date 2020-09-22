using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class LayoutRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/LayoutRules.md");

        public override string SectionName { get; } = "Layout Rules";
    }
}