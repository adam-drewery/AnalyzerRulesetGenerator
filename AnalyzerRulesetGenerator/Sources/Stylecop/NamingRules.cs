using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class NamingRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://raw.githubusercontent.com/DotNetAnalyzers/StyleCopAnalyzers/master/documentation/NamingRules.md");

        public override string SectionName { get; } = "Naming Rules";
    }
}