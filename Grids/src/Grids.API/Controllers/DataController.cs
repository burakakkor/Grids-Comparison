using Grids.Core.Models;
using Grids.Core.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Grids.API.Controllers
{
    [Route("api/data")]
    public class DataController : Controller
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<DataResult> Get(int take, int skip)
        {
            return await _dataService.GetDataAsync(take, skip);
        }
    }
}
