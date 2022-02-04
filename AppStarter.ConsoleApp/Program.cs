using DIHelper;
using Unity;

namespace AppStarter.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        IBootstraper booter = new Bootstraper(
            new UnityDependencySuite(
                new UnityContainer().AddExtension(new Diagnostic())));
        booter.Boot(args);
    }
}