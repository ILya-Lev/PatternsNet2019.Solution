using System.Text;

namespace Creational.BuilderSmartHouse
{
    internal class Application
    {
        private readonly IRelay _relay;
        private readonly IPost _post;
        private readonly IHandler _handler;
        private readonly IScenario _scenario;

        public Application(IRelay r, IHandler h, IPost p, IScenario s)
        {
            _relay = r;
            _handler = h;
            _post = p;
            _scenario = s;
        }

        public string Live()
        {
            var results = new StringBuilder();
            
            results.AppendLine(_relay.On())
                .AppendLine(_post.DoPost())
                .AppendLine(_handler.Handle())
                .AppendLine(_scenario.Execute())
                .AppendLine(_relay.Off());
            
            return results.ToString();
        }
    }
}
