using System;

namespace Structural.Bridge
{
    class Motor : IEngine
    {
        public string turnForward()=>"Motor::turnForward";

        public string turnBack() => "Motor::turnBack";
    }
}
