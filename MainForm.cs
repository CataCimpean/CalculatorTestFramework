using CalculatorTestFramework.Configs;
using CalculatorTestFramework.Services;

namespace CalculatorTestFramework;

partial class MainForm : Form
{
    private readonly ITestConfigService _configService;
    private List<TestSuiteConfig> _loadedSuites = new();

    public MainForm() : this(new TestConfigService()) { }

    public MainForm(ITestConfigService configService)
    {
        _configService = configService;
        InitializeComponent();
    }

    private void BtnLoadConfigs_Click(object? sender, EventArgs e)
    {
        var configDir = Path.Combine(AppContext.BaseDirectory, "TestConfigs");
        try
        {
            _loadedSuites = _configService.LoadFromDirectory(configDir);
            var total = _loadedSuites.Sum(s => s.Tests.Count);
            lblStatus.Text = $"Loaded {_loadedSuites.Count} suite(s), {total} test(s). Click 'Run tests'.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error: {ex.Message}";
        }
    }

    private void BtnRunTests_Click(object? sender, EventArgs e)
    {
        if (_loadedSuites.Count == 0)
        {
            lblStatus.Text = "Load configs first.";
            return;
        }

        lblStatus.Text = "Running...";
        Application.DoEvents();

        var runner = new TestRunner();
        var results = runner.RunAll(_loadedSuites);

        gridResults.DataSource = null;
        gridResults.Columns.Clear();
        gridResults.DataSource = results;

        gridResults.Columns["SuiteName"]!.HeaderText = "Suite";
        gridResults.Columns["SuiteName"]!.DisplayIndex = 0;
        gridResults.Columns["TestName"]!.HeaderText = "Test";
        gridResults.Columns["TestName"]!.DisplayIndex = 1;
        gridResults.Columns["Method"]!.HeaderText = "Method";
        gridResults.Columns["Method"]!.DisplayIndex = 2;
        gridResults.Columns["Arguments"]!.HeaderText = "Arguments";
        gridResults.Columns["Arguments"]!.DisplayIndex = 3;
        gridResults.Columns["Expected"]!.HeaderText = "Expected";
        gridResults.Columns["Expected"]!.DisplayIndex = 4;
        gridResults.Columns["Actual"]!.HeaderText = "Actual";
        gridResults.Columns["Actual"]!.DisplayIndex = 5;
        gridResults.Columns["Passed"]!.HeaderText = "Passed";
        gridResults.Columns["Passed"]!.DisplayIndex = 6;
        gridResults.Columns["ErrorMessage"]!.HeaderText = "Error";
        gridResults.Columns["ErrorMessage"]!.DisplayIndex = 7;

        foreach (DataGridViewRow row in gridResults.Rows)
        {
            if (row.Cells["Passed"].Value is bool passed)
                row.DefaultCellStyle.BackColor = passed ? System.Drawing.Color.FromArgb(220, 255, 220) : System.Drawing.Color.FromArgb(255, 220, 220);
        }

        var passedCount = results.Count(r => r.Passed);
        lblStatus.Text = $"Done: {passedCount}/{results.Count} passed.";
    }
}