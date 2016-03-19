using controller;
using domain.Statement;
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
    public partial class Form1 : Form
    {
        IStmt prg;
        Controller<IStmt> ctr;
       public static bool fileFlag;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StmtMenu m = new StmtMenu();
            m.ShowDialog();
            prg = m.GetPrg();
            this.textBox1.Text = prg.ToString();
            ctr = new Controller<IStmt>(prg);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ctr.OneStepForAllPrg(ctr.GetProgramStateList());
            this.textBox2.Text = ctr.GetProgramStateList().ElementAt(0).ToString();
            if (ctr.GetProgramStateList().Count > 1) this.textBox3.Text = ctr.GetProgramStateList().ElementAt(1).ToString();
            if (ctr.GetProgramStateList().Count > 2) this.textBox4.Text = ctr.GetProgramStateList().ElementAt(2).ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ctr.Serialize();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IStmt stmt = null;
            ctr = new Controller<IStmt>(stmt);
            ctr.Deserialize();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (fileFlag) fileFlag = false;
            else fileFlag = true;
            MessageBox.Show(fileFlag.ToString());
        }
    }
}
