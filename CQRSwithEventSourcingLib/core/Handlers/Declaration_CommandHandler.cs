using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyDI;

namespace CQRSwithEventSourcingLib 
{
    public class Declaration_CommandHandler :           ICommandHandler<Declaration_CreateCommand>,
                                                        ICommandHandler<Declaration_ChangeDescriptionCommand>,
                                                        ICommandHandler<Declaration_ChangeTitleCommand>
    {
        private IRepository<Declaration> repository;
        private IRepository<Event> eventRepository;


        public Declaration_CommandHandler(IRepository<Declaration> repository, IRepository<Event> eventRepository)
        {
            this.repository = repository;
            this.eventRepository = eventRepository;
        }


        public async Task Handle(Declaration_CreateCommand command)
        {
            Declaration declaration = new Declaration() {Id = command.Id, Description = command.Description, Title = command.Title};
            Declaration_CreateEvent declarationCreateEvent = new Declaration_CreateEvent() { Id = command.Id, Description = command.Description, Title = command.Title };
            await repository.Set(declaration);
            await  eventRepository.Set(declarationCreateEvent);
        }

        public async Task Handle(Declaration_ChangeDescriptionCommand command)
        {
            Declaration_ChangeDescriptionEvent declaration_ChangeDescriptionEvent = new Declaration_ChangeDescriptionEvent() { Id = command.Id, NewDescription = command.NewDescription, OldDescription = command.OldDescription };
            await eventRepository.Set(declaration_ChangeDescriptionEvent);
            var obj = await repository.Get(command.Id);
            obj.Description = command.NewDescription;
            await repository.SaveChanges();
        }

        public async Task Handle(Declaration_ChangeTitleCommand command)
        {
            Declaration_ChangeTitleEvent declaration_ChangeTitleEvent = new Declaration_ChangeTitleEvent() { Id = command.Id, NewTitle = command.NewTitle, OldTitle = command.OldTitle };
            await eventRepository.Set(declaration_ChangeTitleEvent);
            var obj = await repository.Get(command.Id);
            obj.Title = command.NewTitle;
            await repository.SaveChanges();
        }


        public Task GoHandle(ICommand command)
        {
           return  ((dynamic)this).Handle((dynamic)command);
        }
    }
}
