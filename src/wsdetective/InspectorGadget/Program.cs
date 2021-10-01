using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InspectorGadget
{
    class Program
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
        static void Main(string[] args)
        {
            MSBuildWorkspace msWorkspace = MSBuildWorkspace.Create();
            msWorkspace.LoadMetadataForReferencedProjects = true;
            var solutionPath = ConfigurationManager.AppSettings["SolutionPath"];

        }
    }
}
