namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        TableLayoutPanel tableLayoutPanel;
        public Form1()
        {
            InitializeComponent();
            InitTable();
            InitButtons();  
        }


        void InitTable()
        {
             tableLayoutPanel = new TableLayoutPanel();
            //this.SuspendLayout();
            
            tableLayoutPanel.ColumnCount = 6; 
            tableLayoutPanel.RowCount = 6;    
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / tableLayoutPanel.ColumnCount));
            }
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / tableLayoutPanel.RowCount));
            }
            tableLayoutPanel.Dock = DockStyle.Fill;
            this.Controls.Add(tableLayoutPanel);
        }
        void InitButtons() {
            for (int row = 0; row < tableLayoutPanel.RowCount; row++)
            {
                for (int col = 0; col < tableLayoutPanel.ColumnCount; col++)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Text = $"Button {row+col}";
                    tableLayoutPanel.Controls.Add(btn, col, row);
                }
            }
        }

    }
}
