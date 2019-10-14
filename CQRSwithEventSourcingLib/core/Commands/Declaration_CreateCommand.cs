using System;
using System.Collections.Generic;
using System.Text;
using TinyDI;

namespace CQRSwithEventSourcingLib
{
    public class Declaration_CreateCommand : ICommand
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
