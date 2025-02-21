using PresentationLayer.Views;

namespace PresentationLayer;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Employee_Dashboard());
    }
}