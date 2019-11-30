using System;

namespace Structural.Bridge
{
    class StepMotor : IEngine
    {
        public string turnForward() => "StepMotor::turnForward";
        public string turnBack() => "StepMotor::Back";
    }
}
