using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyDI;

namespace CQRSwithEventSourcingLib
{
    public class CommandBus : ICommandBus
    {
        TinyDependencyInjection tinyDI;

        public CommandBus(TinyDependencyInjection tinyDI)
        {
            this.tinyDI = tinyDI;
        }


        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            await tinyDI.SendAsync<TCommand>(command);
        }
    }
}
