using System;
using System.IO;
using System.Linq;
using AnalyzerRulesetGenerator.Sources;
using AnalyzerRulesetGenerator.Xml;

namespace AnalyzerRulesetGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new RulesetFile();

            var sources = typeof(Program)
                .Assembly
                .GetTypes()
                .Where(t => typeof(RuleSource).IsAssignableFrom(t))
                .Where(t => !t.IsAbstract)
                .Where(t => t.GetConstructor(new Type[0]) != null)
                .Select(Activator.CreateInstance)
                .Cast<RuleSource>();

            foreach(var source in sources)
            {
                var section = source.GetSection();

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