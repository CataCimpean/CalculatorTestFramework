using CalculatorTestFramework.Services;

namespace CalculatorTestFramework;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var configService = new TestConfigService();
        var testRunner = new TestRunnerService();
        Application.Run(new MainForm(configService, testRunner));
    }
}