using Grids.Core.Services;
using Grids.Core.Services.Base;
using System.Threading.Tasks;
using Xunit;

namespace Grids.Tests
{
    public class GridServiceTests
    {
        private readonly IGridService _gridService;

        public GridServiceTests()
        {
            _gridService = new GridService();
        }

        [Fact]
        public async Task GetGridAsync_should_not_throw_exception_when_read_from_file()
        {
            // Act
            var exception = await Record.ExceptionAsync(async () => {
                var result = await _gridService.GetGridAsync();
            });

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public async Task GetGridAsync_should_not_return_null()
        {
            // Act
            var result = await _gridService.GetGridAsync();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetGridAsync_should_return_result_columns()
        {
            // Act
            var result = await _gridService.GetGridAsync();

            // Assert
            Assert.NotNull(result.Columns);
            Assert.True(result.Columns.Length > 0);
        }
    }
}
