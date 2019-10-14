using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyDI;


namespace CQRSwithEventSourcingLib
{
    public interface ICommandBus
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
