using PresentationLayer.Views;
using ServicesLayer;
using Unity;
using Unity.Lifetime;

namespace PresentationLayer;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        IUnityContainer UnityC = new UnityContainer();
        UnityC.RegisterType<IServicesMesh, ServicesMesh>(new HierarchicalLifetimeManager());

        var servicesManager = UnityC.Resolve<IServicesMesh>();

        ApplicationConfiguration.Initialize();

        var form = new Login_Form(servicesManager);
        Application.Run(form);
    }
}