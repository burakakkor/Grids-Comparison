using Grids.Core.Models;
using System.Threading.Tasks;

namespace Grids.Core.Services.Base
{
    public interface IGridService
    {
        Task<Grid> GetGridAsync();
    }
}
