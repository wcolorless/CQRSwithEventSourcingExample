using System;
using System.Collections.Generic;
using System.Text;
using TinyDI;

namespace CQRSwithEventSourcingLib 
{
    public class DeclarationState : Declaration
    {

        public void On(Declaration_CreateEvent create)
        {
            Id = create.Id;
            Title = create.Title;
            Description = create.Description;
        }

        public void On(Declaration_ChangeTitleEvent newTitle)
        {
            Title = newTitle.NewTitle;
        }

        public void On(Declaration_ChangeDescriptionEvent newDescription)
        {
            Description = newDescription.NewDescription;
        }
        
        public void Mutate(IEvent @event)
        {
            ((dynamic)this).On((dynamic)@event);
        }
    }
}
