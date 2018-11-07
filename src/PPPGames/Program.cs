using Autofac;
using PPPGames.Helpers;
using PPPGames.Infrastructure.Implementation;
using PPPGames.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PPPGames
{
    static class Program
    {

        internal static IContainer container;

        static async Task Main(string[] args)
        {

            Console.WriteLine("PPPGames - Let's get ready !");
            BuildIoCContainer();

            var gameManager = container.Resolve<GameManager>();
            await gameManager.RunGameAsync();

            Console.WriteLine();
            Console.WriteLine("Game finished ! Press enter to exit");
            Console.Read();
        }

        private static void BuildIoCContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<GameManager>().AsSelf();
            containerBuilder.Register(_ => new FileGameSaver(new DirectoryInfo("."))).AsImplementedInterfaces().AsSelf();

            container = containerBuilder.Build();
        }
    }
}
