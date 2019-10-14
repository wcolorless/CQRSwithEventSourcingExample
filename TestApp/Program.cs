using System;
using CQRSwithEventSourcingLib;
using TinyDI;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {

        static async  Task Main(string[] args)
        {
            await Go();
        }

        private static async Task Go()
        {
            Console.WriteLine("Starting");
            Console.WriteLine("Dependency Injection - Register All");
            // Dependency Injection
            var di = new TinyDependencyInjection();
            di.AddDependency(Dependency.Create().For<ICommandHandler<ICommand>>().Use<Declaration_CommandHandler>());
            di.AddDependency(Dependency.Create().For<IRepository<Declaration>>().Use<DeclarationEventsRepository<Declaration>>().SetBehaviour(DIBehaviour.Singleton));
            di.AddDependency(Dependency.Create().For<IRepository<Event>>().Use<DeclarationRepository<Event>>().SetBehaviour(DIBehaviour.Singleton));
            di.AddDependency(Dependency.Create().For<IRepository<Event>>().Use<DeclarationRepository<Event>>().SetBehaviour(DIBehaviour.Singleton));
            di.AddDependency(Dependency.Create().For<IQueryHandler<Declaration_GetQuery, Declaration>>().Use<Declaration_QueryHandler>().SetBehaviour(DIBehaviour.Singleton));
            di.Init(); // Init All Objects

            // CommandBus - need for send Command. 
            var CommandBus = new CommandBus(di);
            // QueryBus - need for send Queries and Receive Data
            var QueryBus = new QueryBus(di);
            Console.WriteLine("Create two Entities");
            // Create two commands which Create Declaration objects in Repos and Write to EventRepo
            var CreateCommand1 = new Declaration_CreateCommand() { Id = "1", Title = "CreateCommand1", Description = "This is First Command1" };
            await CommandBus.SendAsync(CreateCommand1);
            var CreateCommand2 = new Declaration_CreateCommand() { Id = "2", Title = "CreateCommand2", Description = "This is First Command2" };
            await CommandBus.SendAsync(CreateCommand2);

            Console.WriteLine("Get Data From First Entity");
            // Create query and get data about first Declaration object from repo
            var Get1Query = new Declaration_GetQuery() { Id = "1" };
            var res1 = await QueryBus.GetAsync<Declaration_GetQuery, Declaration>(Get1Query);
            var Get2Query = new Declaration_GetQuery() { Id = "2" };
            var res2 = await QueryBus.GetAsync<Declaration_GetQuery, Declaration>(Get2Query);
            Console.WriteLine(string.Format("Id = {0}; Title = {1}; Description = {2}", res1.Id, res1.Title, res1.Description));
            Console.WriteLine(string.Format("Id = {0}; Title = {1}; Description = {2}", res2.Id, res2.Title, res2.Description));
        }
    }
}
