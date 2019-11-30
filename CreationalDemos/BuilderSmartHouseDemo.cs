using Creational.BuilderSmartHouse;
using Xunit;
using Xunit.Sdk;

namespace CreationalDemos
{
    public class BuilderSmartHouseDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        public BuilderSmartHouseDemo(TestOutputHelper output) { _output = output; }

        [Fact]
        public void StraightforwardCase_ComponentBuilder()
        {
            IComponentBuilder builder = new StubComponentBuilder();
            var director = new Director(builder);
            director.Construct();
            Application app = director.GetResult();
            _output.WriteLine(app.Live());
        }

        [Fact]
        public void ApplicationBuilder_FluentApi_CreateApp()
        {
            var app = ApplicationBuilder
                .AddRelay()
                .AddScenario(3)
                .AddHandler()
                .AddPost()
                .AddScenario(1)
                .Build();

            _output.WriteLine(app.Live());
        }

    }
}