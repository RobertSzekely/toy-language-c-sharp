using controller;
using domain.Expression;
using domain.Statement;
using System;
using System.Windows.Forms;
using Test.domain.Expressions;
using Test.domain.Statements;

namespace WindowsFormsApplication2
{
    static class Program 
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
