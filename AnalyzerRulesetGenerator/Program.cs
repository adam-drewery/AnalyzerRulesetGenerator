using System;
using System.Linq;
using System.Threading.Tasks;
using AnalyzerRulesetGenerator.Sources;
using AnalyzerRulesetGenerator.Xml;

namespace AnalyzerRulesetGenerator
{
    internal class Program
    {
        private static async Task Main()
        {
            var file = new RulesetFile();

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
                var section = await source.GetSection();

                file.AnalyzerSettings.Add(new AnalyzerSetting
                {
                    AnalyzerId = source.AnalyzerId,
                    RuleNamespace = source.AnalyzerId,
                    Sections = { section }
                });
            }

            Console.WriteLine(file.Generate());
        }
    }
}