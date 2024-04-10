using System;
using System.Collections.Generic;
using AnalyzerRulesetGenerator.CodeAnalysis;
using HtmlAgilityPack;

namespace AnalyzerRulesetGenerator.Sources.Microsoft.CodeAnalysis.NetAnalyzers;

public class NetAnalyzersRuleSource : RuleSource
{
    public override Uri Uri { get; } = new("https://learn.microsoft.com/en-gb/dotnet/fundamentals/code-analysis/quality-rules/");
    
    public override string AnalyzerId => "Microsoft.CodeAnalysis.NetAnalyzers";
    
    public override string RuleNamespace => AnalyzerId;
    
    public override string SectionName => "Net Analyzers";
    
    public override IEnumerable<AnalyzerRule> GetRules(string document)
    {
        var html = new HtmlDocument();
        html.LoadHtml(document);
        
        var rules = html.DocumentNode.SelectNodes("//html/body/div[2]/div/section/div/div[1]/main/div/div/table/tbody/tr/td[1]/a");

        foreach (var rule in rules)
        {
            var parts = rule.InnerText.Split(": ");
            yield return new AnalyzerRule
            {
                Id = parts[0],
                Action = "Warning",
                Description = parts[1],
                Name = parts[0]
            };
        }
    }
}