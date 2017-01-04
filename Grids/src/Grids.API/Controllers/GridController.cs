using Grids.Core.Models;
using Grids.Core.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Grids.API.Controllers
{
    [Route("api/grid")]
    public class GridController : Controller
    {
        private readonly IGridService _gridService;

        public GridController(IGridService gridService)
        {
            _gridService = gridService;
        }

        [HttpGet]
        public async Task<Grid> Get()
        {
            return await _gridService.GetGridAsync();
        }
    }
}
