using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSwithEventSourcingLib 
{
    public class Declaration_ChangeDescriptionEvent : Event
    {
        public string OldDescription { get; set; }
        public string NewDescription { get; set; }
    }
}
