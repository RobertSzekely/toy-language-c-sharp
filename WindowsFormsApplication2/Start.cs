namespace view
{

    using controller;
    using domain.DataTypes;
    using ArithExp = domain.Expression.ArithExp;
    using ConstExp = domain.Expression.ConstExp;
    using VarExp = domain.Expression.VarExp;
    using AssignStmt = domain.Statement.AssignStmt;
    using CompStmt = domain.Statement.CompStmt;
    using IStmt = domain.Statement.IStmt;
    using IfStmt = domain.Statement.IfStmt;
    using PrintStmt = domain.Statement.PrintStmt;
    using repository;
    using System;
    using Test.domain.Statements;
    using Test.controller;
    using Test.domain.Expressions;
    using System.IO;
    using System.Collections.Generic;
  

    //public class Start
    //{

    //    public static void Main(string[] args)
    //    {
            //Scanner in = new Scanner(System.in);
            //Menu menu = new Menu(in);
            //IStmt program = menu.StatementMenu();

            //IStmt ex1 = new CompStmt(new AssignStmt("v", new ConstExp(2)), new PrintStmt(new VarExp("v")));

            //IStmt ex2 = new CompStmt(new AssignStmt("a", new ArithExp("+", new ConstExp(2), new ArithExp("*", new ConstExp(3), new ConstExp(5)))), new CompStmt(new AssignStmt("b", new ArithExp("+", new VarExp("a"), new ConstExp(1))), new PrintStmt(new VarExp("b"))));

            //IStmt ex3 = new CompStmt(new AssignStmt("a", new ArithExp("-", new ConstExp(2), new ConstExp(2))), new CompStmt(new IfStmt(new VarExp("a"), new AssignStmt("v", new ConstExp(2)), new AssignStmt("v", new ConstExp(3))), new PrintStmt(new VarExp("v"))));


            //IStmt ex4 = new CompStmt(new AssignStmt("v", new ConstExp(6)),
            //    new CompStmt(new WhileStmt(new ArithExp("-", new VarExp("v"), new ConstExp(4)),
            //            new CompStmt(new PrintStmt(new VarExp("v")), new AssignStmt("v", new ArithExp("-", new VarExp("v"),
            //                    new ConstExp(1))))), new PrintStmt(new VarExp("v"))));

            //IStmt readProg = new CompStmt(new AssignStmt("v", new ReadExp()),
            //				new CompStmt(new IfStmt(new BoolExp("!", new VarExp("v")), new IncStmt("v"), new SkipStmt()) , 
            //						new SkipStmt() ));

            //IStmt skipProg = new CompStmt(new AssignStmt("v", new ConstExp(6)),
            //    new IfStmt(new BoolExp("<", new VarExp("v"), new ConstExp(10)), new IncStmt("v"), new SkipStmt()));

            //IStmt switchProg = new CompStmt(new AssignStmt("v", new ConstExp(2)),
            //    new CompStmt(new AssignStmt("a", new ArithExp("+", new VarExp("v"), new ConstExp(10))),
            //         new SwitchStmt(
            //                new VarExp("v"), new ArithExp("-", new VarExp("a"), new ConstExp(11)),
            //                new CompStmt(new IncStmt("a"), new PrintStmt(new VarExp("a"))),
            //                new ArithExp("-", new VarExp("a"), new ConstExp(10)),
            //                new CompStmt(new AssignStmt("a", new ArithExp("+", new VarExp("a"), new ConstExp(2))),
            //                        new PrintStmt(new VarExp("a"))), new PrintStmt(new VarExp("a")))));

            //IStmt heap1 = new CompStmt(new AssignStmt("v", new ConstExp(10)), new CompStmt(new NewHeapStmt("v", new ConstExp(20)),
            //    new CompStmt(new NewHeapStmt("a", new ConstExp(22)), new PrintStmt(new VarExp("v")))));

            //// v=10;new(v,20);new(a,22);print(rH(v));print(rH(a)) at the end of execution Heap={1->20, 2->22}, SymTable={v->1, a->2} and Out={20,22}
            //IStmt heap2 = new CompStmt(new AssignStmt("v", new ConstExp(10)), new CompStmt(new NewHeapStmt("v", new ConstExp(20)), new CompStmt(new NewHeapStmt("a", new ConstExp(22)),
            //         new CompStmt(new PrintStmt(new ReadHeapExp("v")), new PrintStmt(new ReadHeapExp("a"))))));

            ////v=10;new(v,20);new(a,22);wH(a,30);print(a);print(rH(a)) at the end of execution: Heap={1->20, 2->30}, SymTable={v->1, a->2} and Out={2,30}
            //IStmt heap3 = new CompStmt(new AssignStmt("v", new ConstExp(10)), new CompStmt(new NewHeapStmt("v", new ConstExp(20)), new CompStmt(new NewHeapStmt("a", new ConstExp(22)),
            //         new CompStmt(new WriteHeapStmt("a", new ConstExp(30)), new CompStmt(new PrintStmt(new VarExp("a")), new PrintStmt(new ReadHeapExp("a")))))));

            ////v = 10; new(a, 22);
            ////fork(wH(a, 30); v = 32; print(v); print(rH(a)));
            ////print(v); print(rH(a))
            ////    Id = 1
            ////SymTable_1 ={ v->10,a->1}
            ////Id = 10
            ////SymTable_10 ={ v->32,a->1}
            ////Heap ={ 1->30}
            ////Out ={ 32,22,30,30}
            ////or Out = { 22, 32, 30, 30 }

            //IStmt forkStmt = new ForkStmt(new CompStmt(new WriteHeapStmt("a", new ConstExp(30)),
            //        new CompStmt(new AssignStmt("v", new ConstExp(32)),
            //        new CompStmt(new PrintStmt(new VarExp("v")), new PrintStmt(new ReadHeapExp("a"))))));

            //IStmt lab9 = new CompStmt(new AssignStmt("v", new ConstExp(10)),
            //    new CompStmt(new NewHeapStmt("a", new ConstExp(22)),
            //    new CompStmt(forkStmt, new CompStmt(new PrintStmt(new VarExp("v")), new PrintStmt(new ReadHeapExp("a"))))));
                


            //Controller<Object> ctr = new Controller<Object>(lab9);
            

            //in.close();
        //    int n;
        //    do
        //    {
        //        Console.WriteLine("\nChoose:\n"
        //            + "0 - Exit\n"
        //            + "1 - One step for all prg\n"
        //            + "2 - All Step\n"
        //            + "3 - Debug\n"
        //            + "4 - Serialize\n"
        //            + "5 - Deserialize\n");

        //        n = PromptForInput();

        //        switch (n)
        //        {
        //            case 0:
        //                Environment.Exit(0);
        //                break;
        //            case 1:

        //                ctr.OneStepForAllPrg(ctr.GetProgramStateList());
                        
        //                break;
        //            case 2:
        //                try
        //                {
        //                    ctr.AllStep();
        //                }
        //                catch (ControllerException e)
        //                {
        //                    Console.WriteLine(e.StackTrace);
        //                }
        //                break;
        //            //case 3:
        //            //    ctr.Debug();
        //            //    break;
        //            //case 4:
        //            //    ctr.Serialize(ctr.GetProgramState());
        //            //    break;
        //            //case 5:
        //            //    ctr.SetProgramState(ctr.Deserialize());
        //            //    ctr.DisplayState();
        //            //    break;
        //            default:
        //                try
        //                {
        //                    ctr.AllStep();
        //                }
        //                catch (ControllerException e)
        //                {
        //                    Console.WriteLine(e.StackTrace);
        //                }
        //                break;


        //        }

                

        //    } while (ctr.GetProgramStateList().Count > 0);
        //}


        //public static int PromptForInput()
        //{
        //    try
        //    {
        //        int n;
        //        Console.Write("> ");
        //        while (!int.TryParse(Console.ReadLine(), out n))
        //            Console.WriteLine("Try again: ");
        //        return n;
        //    }
        //    catch(IOException)
        //    {
        //        Console.WriteLine("Invalid input!");
        //        return PromptForInput();
        //    }
            

            
    //    }//end of main




    //}//end of class

    
}//end of namespace