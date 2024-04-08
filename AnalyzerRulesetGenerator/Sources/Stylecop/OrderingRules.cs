using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class OrderingRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://raw.githubusercontent.com/DotNetAnalyzers/StyleCopAnalyzers/master/documentation/OrderingRules.md");

        public override string SectionName { get; } = "Ordering Rules";
    }
}