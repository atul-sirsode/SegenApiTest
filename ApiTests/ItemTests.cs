using SegenApi.Controllers;
using Xunit;

namespace ApiTests
{
    public class ItemTests
    {
        [Fact]
        public void GetItemsReturnsOnlyOne()
        {
            var controller = new ItemController();
            var items = controller.GetItems();

            Assert.Single(items);
        }
    }
}