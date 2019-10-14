using System;
using System.Collections.Generic;
using System.Text;
using TinyDI;

namespace CQRSwithEventSourcingLib 
{
    public class DeclarationAggregator
    {
        private readonly DeclarationState _declarationState;

        public DeclarationAggregator()
        {
            _declarationState = new DeclarationState();
        }


        public void ChangeTitle(string newTitle)
        {
            if(_declarationState.Title != newTitle)
            {
                Apply(new Declaration_ChangeTitleEvent() {Id = _declarationState.Id, NewTitle = newTitle, OldTitle = _declarationState.Title });
            }
        }

        public void ChangeDescription(string newDescription)
        {
            if (_declarationState.Description != newDescription)
            {
                Apply(new Declaration_ChangeDescriptionEvent() { Id = _declarationState.Id, NewDescription = newDescription, OldDescription = _declarationState.Description});
            }
        }

        private void Apply(IEvent evt)
        {
            _declarationState.Mutate(evt);
        }

    }

    
}
