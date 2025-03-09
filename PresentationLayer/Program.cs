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
        Syncfusion.Licensing
            .SyncfusionLicenseProvider
            .RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF1cVGhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEBjWn9ZcnRQQGNaU0xxXw==");

        IUnityContainer UnityC = new UnityContainer();
        UnityC.RegisterType<IServicesMesh, ServicesMesh>(new HierarchicalLifetimeManager());

        var servicesManager = UnityC.Resolve<IServicesMesh>();

        ApplicationConfiguration.Initialize();

        var form = new Login_Form(servicesManager);
        Application.Run(form);
    }
}