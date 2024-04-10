using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AnalyzerRulesetGenerator.CodeAnalysis;

namespace AnalyzerRulesetGenerator.Sources.Stylecop;

public abstract partial class StylecopRuleSource : RuleSource
{
    public override string AnalyzerId => "Stylecop.Analyzers";

    public override string RuleNamespace => AnalyzerId;

    public override IEnumerable<AnalyzerRule> GetRules(string document)
    {
        return 
            from line
            in document.Split("\n")
            where line.StartsWith('[')
            select line.Split(" | ")
            into parts
            where parts.Length == 3
            select new AnalyzerRule
            {
                Id = MyRegex().Match(parts[0]).Groups[1].Value,
                Name = parts[1],
                Action = "Warning",
                Description = parts[2]
            };
    }

    [GeneratedRegex(@"\[([^\]]+)\]")]
    private static partial Regex MyRegex();
}