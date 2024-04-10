using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyzerRulesetGenerator.CodeAnalysis;
using AnalyzerRulesetGenerator.EditorConfig;
using AnalyzerRulesetGenerator.Sources;

namespace AnalyzerRulesetGenerator;

internal class Program
{
    private static async Task Main()
    {
        var file = new RulesetFile();
        var configSections = new List<ConfigSection>();

        var sources = typeof(Program)
            .Assembly
            .GetTypes()
            .Where(t => typeof(RuleSource).IsAssignableFrom(t))
            .Where(t => !t.IsAbstract)
            .Where(t => t.GetConstructor(Type.EmptyTypes) != null)
            .Select(Activator.CreateInstance)
            .Cast<RuleSource>();

        foreach(var source in sources)
        {
            var analyzerSettingSection = await source.GetSection();
            var editorConfigSection = new ConfigSection(source.SectionName);
            configSections.Add(editorConfigSection);

            file.AnalyzerSettings.Add(new AnalyzerSetting
            {
                AnalyzerId = source.AnalyzerId,
                RuleNamespace = source.AnalyzerId,
                Sections = { analyzerSettingSection }
            });
            
            foreach(var rule in analyzerSettingSection.Rules)
                editorConfigSection.Rules.Add(new ConfigRule(rule.Id, rule.Description));
        }

        Console.WriteLine(file.Generate());

        foreach (var section in configSections) 
            Console.WriteLine(section);
    }
}