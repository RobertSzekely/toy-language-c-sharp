using System;

namespace view
{

    using ArithExp = domain.Expression.ArithExp;
    using ConstExp = domain.Expression.ConstExp;
    using Exp = domain.Expression.Exp;
    using VarExp = domain.Expression.VarExp;
    using AssignStmt = domain.Statement.AssignStmt;
    using CompStmt = domain.Statement.CompStmt;
    using IStmt = domain.Statement.IStmt;
    using IfStmt = domain.Statement.IfStmt;
    using PrintStmt = domain.Statement.PrintStmt;
    

    public class Menu
    {

        public Menu()
        { 
        }

        /// 
        public virtual IStmt StatementMenu()
        {
            Console.WriteLine("Choose statement: \n" + "1: If Statement\n" + "2: PrintStatement\n" + "3: AssignmentStatement\n" + "4: CopoundStatement\n");

            string input = Console.ReadLine();
            int n = Convert.ToInt32(input);

            switch (n)
            {
                case 1:
                    return new IfStmt(ExpressionMenu(), StatementMenu(), StatementMenu());
                case 2:
                    return new PrintStmt(ExpressionMenu());
                case 3:
                    Console.WriteLine("Give the name of the variable: ");
                    string variable = Console.ReadLine();
                    return new AssignStmt(variable, ExpressionMenu());
                case 4:
                    return new CompStmt(StatementMenu(), StatementMenu());
                default:
                    Console.WriteLine("Wrong command");
                    return StatementMenu();
            }
        }
        /// 
        public virtual Exp ExpressionMenu()
        {
            Console.WriteLine("Choose expression:\n" + "1-Arithmetic Expression\n" + "2-Variable Expression\n" + "3-Constant Expression\n");
            string input = Console.ReadLine();
            int n = Convert.ToInt32(input);
            switch (n)
            {
                case 1:
                    Console.WriteLine("Give the operator: ");
                    string @operator = Console.ReadLine();
                    return new ArithExp(@operator, ExpressionMenu(), ExpressionMenu());
                case 2:
                    Console.WriteLine("Give variable name: ");
                    string variable = Console.ReadLine();
                    return new VarExp(variable);
                case 3:
                    Console.WriteLine("Give a number: ");
                    string inp = Console.ReadLine();
                    int number = Convert.ToInt32(input);
                    return new ConstExp(number);
                default:
                    Console.WriteLine("Try again \n");
                    return ExpressionMenu();

            }
        }











    }

}