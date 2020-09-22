using System;

namespace AnalyzerRulesetGenerator.Sources.Stylecop
{
    public class DocumentationRules : StylecopRuleSource
    {
        public override Uri Uri { get; } = new Uri("https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/DocumentationRules.md");

        public override string SectionName { get; } = "Documentation Rules";
    }
}