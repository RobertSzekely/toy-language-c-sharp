using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class GetStringInput : Form
    {
        string input;

        public GetStringInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input = this.textBox1.Text;
            Close();
        }

        public string GetInput()
        {
            return input;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
