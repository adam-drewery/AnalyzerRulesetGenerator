namespace AnalyzerRulesetGenerator.CodeAnalysis
{
    public static class Element
    {
        public static string Header() => "<?xml version=\"1.0\" encoding=\"utf-16\"?>";

        public static string RuleSet(string name) => $"<RuleSet Name=\"{name}\" ToolsVersion=\"14.0\">";

        public static string Rules(string analyzerId, string @namespace) => $"    <Rules AnalyzerId=\"{analyzerId}\" RuleNamespace=\"{@namespace}\">";

        public static string SectionHeader(string title) => $"        <!-- {title} -->";

        public static string Rule(string id, string action, string description)
        {
            description = description.Replace("\n", string.Empty).Replace("\r", string.Empty);
            return $"        <Rule Id=\"{id}\" Action=\"{action}\"/><!-- {description} -->";
        }

        public static string Close(int indent, string name) => new string(' ', indent * 4) + $"</{name}>";
    }
}