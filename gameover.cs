using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarGame
{
    public partial class gameover : Form
    {
        public gameover()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            
        }

        private void restart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Hide();
            Form f = new Form1();
            f.ShowDialog();
        }

        private void gameover_Load(object sender, EventArgs e)
        {

        }
    }
}
