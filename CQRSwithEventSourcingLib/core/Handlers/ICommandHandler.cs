using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinyDI;

namespace CQRSwithEventSourcingLib 
{
    public interface ICommandHandler<ICommand>
    {
        Task Handle(ICommand request);
    }
}
