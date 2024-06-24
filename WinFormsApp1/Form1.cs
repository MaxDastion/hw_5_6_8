using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialButton();
        }
        void InitialButton()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button button = new Button
                    {
                        Text = $"Button {row * 3 + col + 1}",
                        Dock = DockStyle.Fill
                    };
                    button.Click += Button_Click;
                    tableLayoutPanel1.Controls.Add(button, col, row);
                }
            }

        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                MessageBox.Show($"{button.Text}");
            }
        }
    }
}
