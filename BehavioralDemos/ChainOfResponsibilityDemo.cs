using System;
using Behavioral.ChainOfResponsibility;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace BehavioralDemos
{
    public class ChainOfResponsibilityDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        private readonly IHandler<string,string> _chainSmallBigNull;

        public ChainOfResponsibilityDemo(TestOutputHelper output)
        {
            _output = output; 
            
            var nullHandler = new NullMessageHandler();                 //this is the tail of the chain
            var bigHandler = new BigMessageHandler(11, nullHandler);
            _chainSmallBigNull = new SmallMessageHandler(7, bigHandler);//this is the head of the chain
        }
        
        [InlineData("alpha")]   //length < 7
        [InlineData("alpha is the first greek alphabet symbol")]   //length > 11
        [InlineData(null)]
        [Theory]
        public void SmallBigNull_MessageWhichWillFitIn_Handled(string message)
        {
            var result = _chainSmallBigNull.Handle(message);
            
            result.Should().NotBeNullOrWhiteSpace();
            _output.WriteLine(result);
        }

        [Fact]
        public void SmallBigNull_UnhandableMessage_Exception()
        {
            string message = "8symbols";
            message.Should().HaveLength(8);


            Action handling = () => _chainSmallBigNull.Handle(message);

            var exc = handling.Should().Throw<Exception>().Which;
            _output.WriteLine(exc.Message);
        }

        [Fact]
        public void BigSmall_NullMessage_Exception()
        {
            var smallHandler = new SmallMessageHandler(10);
            var bigHandler = new BigMessageHandler(15, smallHandler);

            Action handling = () => bigHandler.Handle(null);

            var exc = handling.Should().Throw<Exception>().Which;
            _output.WriteLine(exc.Message);
        }
    }
}
