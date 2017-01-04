using Grids.Core.Models;
using Grids.Core.Services.Base;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Grids.Core.Services
{
    public class GridService : IGridService
    {
        private const string AssemblyName = "Grids.Core";

        public async Task<Grid> GetGridAsync()
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

            var columns = jObject?["data"]?.First().Select(x =>
            {
                // Random boolean for some feature setting just add setting to class with JsonProperty which same as 
                // KendoUI feature name and it will render on UI
                var boolean = GetRandomBoolean();

                // Json property names are our column names
                var columnName = ((JProperty)x).Name;

                return new GridColumn
                {
                    Field = columnName,
                    Title = columnName,
                    IsLocked = false, // default setting false
                    IsLockable = boolean, // some of the columns could be lockable
                    Width = 250
                };
            }).ToArray();

            return new Grid { Columns = columns };
        }

        private bool GetRandomBoolean()
        {
            return new Random().NextDouble() >= 0.5;
        }
    }
}
