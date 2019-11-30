// ReSharper disable TypeParameterCanBeVariant

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BehavioralDemos")]
namespace Behavioral.ChainOfResponsibility
{
    /// <summary>
    /// dummy example to illustrate the basic idea of the pattern
    /// type parameters in this case are redundant
    /// </summary>
    public interface IHandler<TMessage, TResponse>
    {
        bool CanHandle(TMessage message);
        TResponse Handle(TMessage message);
    }
}