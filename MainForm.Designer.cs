#nullable enable
namespace CalculatorTestFramework;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;
    private TableLayoutPanel tableLayout = null!;
    private Panel topPanel = null!;
    private Label lblTitle = null!;
    private Button btnLoadConfigs = null!;
    private Button btnRunTests = null!;
    private Label lblStatus = null!;
    private DataGridView gridResults = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        tableLayout = new TableLayoutPanel();
        topPanel = new Panel();
        lblTitle = new Label();
        btnLoadConfigs = new Button();
        btnRunTests = new Button();
        lblStatus = new Label();
        gridResults = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)gridResults).BeginInit();
        SuspendLayout();

        tableLayout.ColumnCount = 1;
        tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayout.RowCount = 2;
        tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
        tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayout.Dock = DockStyle.Fill;
        tableLayout.Controls.Add(topPanel, 0, 0);
        tableLayout.Controls.Add(gridResults, 0, 1);

        topPanel.Dock = DockStyle.Fill;
        topPanel.Padding = new Padding(8);
        topPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        lblTitle.Location = new System.Drawing.Point(12, 8);
        lblTitle.Text = "Calculator Test Framework";

        btnLoadConfigs.Text = "Load configs (TestConfigs)";
        btnLoadConfigs.Location = new System.Drawing.Point(12, 38);
        btnLoadConfigs.Size = new System.Drawing.Size(180, 28);
        btnLoadConfigs.Click += BtnLoadConfigs_Click;

        btnRunTests.Text = "Run tests";
        btnRunTests.Location = new System.Drawing.Point(200, 38);
        btnRunTests.Size = new System.Drawing.Size(120, 28);
        btnRunTests.Click += BtnRunTests_Click;

        lblStatus.AutoSize = true;
        lblStatus.Location = new System.Drawing.Point(330, 44);
        lblStatus.Text = "Load configs, then run tests.";

        topPanel.Controls.Add(lblTitle);
        topPanel.Controls.Add(btnLoadConfigs);
        topPanel.Controls.Add(btnRunTests);
        topPanel.Controls.Add(lblStatus);

        gridResults.Dock = DockStyle.Fill;
        gridResults.AllowUserToAddRows = false;
        gridResults.AllowUserToDeleteRows = false;
        gridResults.ReadOnly = true;
        gridResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        gridResults.RowHeadersVisible = false;
        gridResults.ColumnHeadersVisible = true;
        gridResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        gridResults.ColumnHeadersHeight = 40;
        gridResults.EnableHeadersVisualStyles = false;
        gridResults.BackgroundColor = System.Drawing.SystemColors.Window;
        gridResults.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(200, 240, 200);
        gridResults.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        gridResults.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
        gridResults.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        gridResults.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        gridResults.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        gridResults.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        gridResults.BorderStyle = BorderStyle.FixedSingle;
        gridResults.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

        Controls.Add(tableLayout);

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(900, 500);
        MinimumSize = new System.Drawing.Size(600, 400);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Calculator Test Framework";

        ((System.ComponentModel.ISupportInitialize)gridResults).EndInit();
        ResumeLayout(false);
    }
}
