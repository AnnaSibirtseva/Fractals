using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractals1._7
{
    public partial class FractalForm : Form
    {
        public FractalForm()
        {
            InitializeComponent();
            MaximumSize = SystemInformation.PrimaryMonitorSize;
            MinimumSize = new Size(MaximumSize.Width / 2, MaximumSize.Height / 2);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Choice start = new Choice();
            start.Show();
        }
    }
}
