using domain.Expression;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.domain.Expressions;

namespace WindowsFormsApplication2
{
    public partial class ExpMenuForm : Form
    {
        Exp exp;

        public ExpMenuForm()
        {
            InitializeComponent();
        }

        public Exp GetExp()
        {
            return exp;
        }

        public Exp GetExpMenu()
        {
            ExpMenuForm f = new ExpMenuForm();
            f.ShowDialog();
            return f.GetExp();
        }

        public string GetString()
        {
            GetStringInput inp = new GetStringInput();
            inp.ShowDialog();
            
            return inp.GetInput();
        }

        public int GetInt()
        {
            GetIntInput inp = new GetIntInput();
            inp.ShowDialog();
            


            return Int32.Parse(inp.GetText());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            exp = new ConstExp(GetInt());
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exp = new ArithExp(GetString(), GetExpMenu(), GetExpMenu());
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exp = new BoolExp(GetString(), GetExpMenu());
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exp = new ReadExp();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            exp = new ReadHeapExp(GetString());
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            exp = new VarExp(GetString());
            Close();
        }
    }
}
