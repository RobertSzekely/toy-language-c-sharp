using domain.Expression;
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
using Test.domain.Statements;

namespace WindowsFormsApplication2
{
    public partial class StmtMenu : Form
    {
        IStmt prg;

        public StmtMenu()
        {
            InitializeComponent();
            
       
        }

        public IStmt ShowMenu()
        {
            StmtMenu m = new StmtMenu();
            m.ShowDialog();
            return m.prg;
        }

        public String GetString()
        {
            GetStringInput inp = new GetStringInput();
            inp.ShowDialog();
            Close();
            return inp.GetInput();
        }

        public Exp GetExp()
        {
            ExpMenuForm f = new ExpMenuForm();
            f.ShowDialog();
            return f.GetExp();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            prg = new CompStmt( ShowMenu(),ShowMenu());
            this.textBox1.Text = prg.ToString();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prg = new AssignStmt(GetString(), GetExp());
            this.textBox1.Text = prg.ToString();
            Close();
        }

        public IStmt GetPrg()
        {
            return prg;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            prg = new IfStmt(GetExp(), ShowMenu(), ShowMenu());
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            prg = new IncStmt(GetString());
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            prg = new ForkStmt(ShowMenu());
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            prg = new NewHeapStmt(GetString(), GetExp());
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            prg = new PrintStmt(GetExp());
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            prg = new SkipStmt();
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            prg = new SwitchStmt(GetExp(), GetExp(), ShowMenu(), GetExp(), ShowMenu(), ShowMenu());
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            prg = new WhileStmt(GetExp(), ShowMenu());
            Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            prg = new WriteHeapStmt(GetString(), GetExp());
            Close();
        }
    }
}
