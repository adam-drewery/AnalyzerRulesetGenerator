using System.Collections.Generic;
using System.Text;

namespace AnalyzerRulesetGenerator.EditorConfig;

public class ConfigSection(string name)
{
    public string Name { get; set; } = name;

    public ICollection<ConfigRule> Rules { get; } = new List<ConfigRule>();

    public override string ToString()
    {
        var builder = new StringBuilder();
        var title = $"### {Name.ToUpperInvariant()} ###";
        builder.AppendLine("##" + new string('-', title.Length - 4) + "##");
        builder.AppendLine(title);
        builder.AppendLine("##" + new string('-', title.Length - 4) + "##");
        builder.AppendLine();
        
        foreach(var rule in Rules)
        {
            builder.AppendLine(rule.ToString());
            builder.AppendLine();
        }

        return builder.ToString();
    }
}