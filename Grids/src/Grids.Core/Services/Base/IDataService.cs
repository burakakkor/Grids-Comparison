using Grids.Core.Models;
using System.Threading.Tasks;

namespace Grids.Core.Services.Base
{
    public interface IDataService
    {
        Task<DataResult> GetDataAsync(int take, int skip);
    }
}
