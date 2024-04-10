using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AnalyzerRulesetGenerator.CodeAnalysis;

namespace AnalyzerRulesetGenerator.Sources.Microsoft.VisualStudio.Threading.Analyzers;

public class ThreadingAnalyzerRuleSource : RuleSource
{
    public override Uri Uri => new("https://raw.githubusercontent.com/microsoft/vs-threading/main/doc/analyzers/index.md");

    public override string AnalyzerId => "Microsoft.VisualStudio.Threading.Analyzers";

    public override string RuleNamespace => AnalyzerId;

    public override string SectionName => "Threading Analyzers";

    public override IEnumerable<AnalyzerRule> GetRules(string document)
    {
        return 
            from line
                in document.Split("\n")
            where line.StartsWith('[')
            select line.Split(" | ")
            into parts
            where parts.Length == 5
            select new AnalyzerRule
            {
                Id = Regex.Match(parts[0], @"\[([^\]]+)\]").Groups[1].Value,
                Name = Regex.Match(parts[0], @"\[([^\]]+)\]").Groups[1].Value,
                Action = "Warning",
                Description = parts[1]
            };
    }
}