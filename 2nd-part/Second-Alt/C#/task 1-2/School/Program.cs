using Autofac;
using School.Interfaces;

namespace School
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bootstrapper.Initialize();

            using (var scope = Bootstrapper.Container.BeginLifetimeScope())
            {
                var terminal = scope.Resolve<ITerminal>();

                terminal.Run();
            }
        }
    }
}
