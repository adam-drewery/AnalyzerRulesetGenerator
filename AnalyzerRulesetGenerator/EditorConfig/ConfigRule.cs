using System;

namespace AnalyzerRulesetGenerator.EditorConfig;

public class ConfigRule(string id, string description)
{
    public string Id { get; set; } = id;

    public string Description { get; set; } = description;

    public string Action { get; set; } = "warning";

    public override string ToString()
    {
        return $"# {Id}: {Description}{Environment.NewLine}dotnet_diagnostic.{Id}.severity = {Action}";
    }
}