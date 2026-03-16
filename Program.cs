using CalculatorTestFramework.Services;

namespace CalculatorTestFramework;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var configService = new TestConfigService();
        Application.Run(new MainForm(configService));
    }
}