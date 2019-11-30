using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    abstract class Command : ICommand
    {
        protected readonly IUseCase useCase;

        public Command(IUseCase uc)
        {
            useCase = uc;
        }
        public virtual void Execute()
        {
           useCase.Action();
        }

        public virtual void  Undo()
        {
        }
    }
}
