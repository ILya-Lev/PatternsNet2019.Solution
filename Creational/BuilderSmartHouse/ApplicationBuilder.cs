using System.Collections.Generic;

namespace Creational.BuilderSmartHouse
{
    internal class ApplicationBuilder
    {
        private readonly IList<IRelay> _relay = new List<IRelay>();
        private readonly IList<IPost> _post = new List<IPost>();
        private readonly IList<IScenario> _scenario = new List<IScenario>();
        private readonly IList<IHandler> _handler = new List<IHandler>();

        public static ApplicationBuilder AddRelay()
        {
            var ab = new ApplicationBuilder();
            ab._relay.Add(new Relay());
            return ab;
        }

        public ApplicationBuilder AddPost()
        {
            _post.Add(new Post());
            return this;
        }

        public ApplicationBuilder AddScenario(int i)
        {
            _scenario.Add(new Scenario(i));
            return this;
        }

        public ApplicationBuilder AddHandler()
        {
            _handler.Add(new Handler());
            return this;
        }

        public FancyApplication Build()
        {
            return new FancyApplication(_relay, _handler, _post, _scenario);
        }

    }
}