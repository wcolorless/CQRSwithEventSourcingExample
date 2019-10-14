using System;
using System.Collections.Generic;
using System.Text;
using TinyDI;

namespace CQRSwithEventSourcingLib
{
    public class Declaration_ChangeDescriptionCommand : ICommand
    {
        public string Id { get; set; }
        public string OldDescription { get; set; }
        public string NewDescription { get; set; }
    }
}
