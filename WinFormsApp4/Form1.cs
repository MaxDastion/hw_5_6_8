namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.LostFocus += new System.EventHandler(textBox1_LostFocus);
            textBox1.GotFocus += new System.EventHandler(textBox1_GotFocus);
            textBox1.Text = string.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text =  $"{textBox1.Text.Length}";
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            textBox1.Text = string.Empty;
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText();
        }
    }
}
// δη 8