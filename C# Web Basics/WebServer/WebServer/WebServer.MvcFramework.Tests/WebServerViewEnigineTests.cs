using WebServer.MvcFramework.ViewEngine;

namespace WebServer.MvcFramework.Tests
{
    public class WebServerViewEnigineTests
    {
        [Theory]
        [InlineData("Foreach")]
        [InlineData("CleanData")]
        [InlineData("IfElseFor")]
        [InlineData("ViewModel")]
        public void TestGetHtml(string fileName)
        {
            IViewEngine viewEngine = new WsViewEngine();
            TestViewModel viewModel = new TestViewModel()
            {
                Name = "Doggo Arghentino",
                DateOfBirth = new DateTime(2019,6,1),
                Price = 12345.67m
            };

            var view = File.ReadAllText($"ViewTests/{fileName}.html");
            var result = viewEngine.GetHtml(view, viewModel);
            var expectedResult = File.ReadAllText($"ViewTests/{fileName}Result.html");

            Assert.Equal(expectedResult, result);
        }

        public class TestViewModel
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public DateTime DateOfBirth { get; set; }
        }
    }
}