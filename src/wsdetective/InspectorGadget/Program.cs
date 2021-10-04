using InspectorGadget.Utility;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InspectorGadget
{
    static class Program
    {
        /*
            * 
            * Web Service sınıflarında WebService veya WebServiceBinding niteliklerini uygulanmakta.
            * Örneğin
            * [WebService(Namespace = "http://tempuri.org/")]
            * [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
            * 
            * Web metotlarında ise WebMethod niteliği kullanılıyor.
       */

        static async Task Main()
        {
            // Console ve dosyaya log düşürmek istiyorum. Observer kullanmak işimi kolaylaştırdı.
            ProcessNotifier postman = new ProcessNotifier();
            postman.Add(new ConsoleNotify());
            var sBuilderNotifier = new StringBuilderNotify();
            postman.Add(sBuilderNotifier);

            MSBuildWorkspace msWorkspace = MSBuildWorkspace.Create();
            msWorkspace.LoadMetadataForReferencedProjects = true;
            var solutionPath = ConfigurationManager.AppSettings["SolutionPath"]; // Komut satırından alabilir miyiz?

            var solution = await msWorkspace.OpenSolutionAsync(solutionPath);
            foreach (var project in solution.Projects) // Çözüm içindeki projeleri dolaş
            {
                postman.Publish($"Project '{project.Name}' Analysis Start.");
                var webServiceCount = 0;
                foreach (var document in project.Documents) // Projedeki dokümanları dolaş
                {
                    var syntaxTree = document.GetSyntaxTreeAsync();
                    var documentRoot = syntaxTree.Result.GetRoot();

                    var classess = documentRoot.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList(); // O anki proje dokümanındaki sınıfları çek
                    foreach (var c in classess) // sınıfları dolaş
                    {
                        foreach (var a in c.AttributeLists) // sınıflara uygulanan nitelikler listesini çek
                        {
                            if (a.ToFullString().Contains("WebService")) // Eğer nitelik WebService kelimesi içeriyorsa (Daha güçlü bir yol bulabilir miyiz?)
                            {
                                postman.Publish($"XML Web Service\t{c.Identifier.ToFullString()}");
                                var methods = c.DescendantNodes().OfType<MethodDeclarationSyntax>().ToList(); // Metotları çek

                                foreach (var method in methods) // Metotları dolaşmaya başla
                                {
                                    foreach (var ma in method.AttributeLists) // O anki metodun niteliklerine geç
                                    {
                                        if (ma.ToFullString().Contains("WebMethod")) // Nitelik tanımında WebMethod kelimesi geçiyor mu? (Tip güvenli bir yol bulabilir miyiz?)
                                        {
                                            postman.Publish($"\t\t{ma}\n\t\t{method.Identifier} : {method.ReturnType}");
                                            var parameterListSyntax = method.ParameterList; // Parametreleri çek
                                            foreach (var prm in parameterListSyntax.Parameters)
                                            {
                                                postman.Publish($"\t\t\t{prm.Identifier} : {prm.Type}");
                                            }
                                        }
                                    }
                                }
                                webServiceCount++;
                                break;
                            }
                        }
                    }                    
                }
                postman.Publish($"\n{project.Name}\tWeb Service Sayısı:{webServiceCount}");
                postman.Publish($"Project '{project.Name}' Analysis End.");
            }

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "AnalysisReport.txt"), sBuilderNotifier.GetText());
        }
    }
}
