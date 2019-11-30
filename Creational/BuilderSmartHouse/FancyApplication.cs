using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Creational.BuilderSmartHouse
{
    internal class FancyApplication
    {
        private readonly IReadOnlyList<IRelay> _relay;
        private readonly IReadOnlyList<IPost> _post;
        private readonly IReadOnlyList<IHandler> _handler;
        private readonly IReadOnlyList<IScenario> _scenario;

        public FancyApplication(IList<IRelay> r, IList<IHandler> h, IList<IPost> p, IList<IScenario> s)
        {
            _relay = (IReadOnlyList<IRelay>) r;
            _handler = (IReadOnlyList<IHandler>) h;
            _post = (IReadOnlyList<IPost>) p;
            _scenario = (IReadOnlyList<IScenario>) s;
        }

        public string Live()
        {
            var results = new StringBuilder();

            _relay.Select(r => results.AppendLine(r.On())).ToArray();
            _post.Select(p => results.AppendLine(p.DoPost())).ToArray();
            _handler.Select(h => results.AppendLine(h.Handle())).ToArray();
            _scenario.Select(s => results.AppendLine(s.Execute())).ToArray();
            _relay.Select(r => results.AppendLine(r.Off())).ToArray();

            return results.ToString();
        }
    }
}