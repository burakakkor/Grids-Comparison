using Grids.Core.Services;
using Grids.Core.Services.Base;
using System.Threading.Tasks;
using Xunit;

namespace Grids.Tests
{
    public class DataServiceTests
    {
        private readonly IDataService _dataService;

        private const int _take = 50, _skip = 0;

        public DataServiceTests()
        {
            _dataService = new DataService();
        }

        [Fact]
        public async Task GetDataAsync_should_not_throw_exception_when_read_from_file()
        {
            // Act
            var exception = await Record.ExceptionAsync(async () => {
                var result = await _dataService.GetDataAsync(_take, _skip);
            });

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public async Task GetDataAsync_should_not_return_null()
        {
            // Act
            var result = await _dataService.GetDataAsync(_take, _skip);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDataAsync_should_return_result_data()
        {
            // Act
            var result = await _dataService.GetDataAsync(_take, _skip);

            // Assert
            Assert.True(result.Data.Length > 0);
        }

        [Fact]
        public async Task GetDataAsync_should_return_result_total()
        {
            // Act
            var result = await _dataService.GetDataAsync(_take, _skip);

            // Assert
            Assert.True(result.Total > 0);
        }
    }
}
