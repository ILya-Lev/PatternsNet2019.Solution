namespace Creational.BuilderSmartHouse
{
    internal class Director
    {
        private IRelay _relay;
        private IPost _post;
        private IHandler _handler;
        private IScenario _scenario;

        private readonly IComponentBuilder _componentBuilder;
        public Director(IComponentBuilder b)
        {
            _componentBuilder = b;
        }

        public void Construct()
        {
            _relay = _componentBuilder.CreateRelay();
            _post = _componentBuilder.CreatePost();
            _handler = _componentBuilder.CreateHandler();
            _scenario = _componentBuilder.CreateScenario();
        }

        public Application GetResult()
        {
            return new Application(_relay, _handler, _post, _scenario);
        }
    }
}
