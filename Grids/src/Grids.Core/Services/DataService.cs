using Grids.Core.Models;
using Grids.Core.Services.Base;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Grids.Core.Services
{
    public class DataService : IDataService
    {
        private const string AssemblyName = "Grids.Core";

        public async Task<DataResult> GetDataAsync(int take, int skip)
        {
            var assemblyName = new AssemblyName(AssemblyName);
            var assembly = Assembly.Load(assemblyName);
            var resourceName = $"{AssemblyName}.Assets.data-1.json";

            string jResult;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                jResult = await reader.ReadToEndAsync();
            }

            var jObject = JObject.Parse(jResult);
            var jData = jObject["data"];
            var jArray = jData.Skip(skip).Take(take).ToArray();

            return new DataResult { Total = jData.Count(), Data = jArray };
        }
    }
}
