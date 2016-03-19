namespace controller
{
    using domain.DataTypes;
    using Exp = domain.Expression.Exp;
    using AssignStmt = domain.Statement.AssignStmt;
    using CompStmt = domain.Statement.CompStmt;
    using IStmt = domain.Statement.IStmt;
    using IfStmt = domain.Statement.IfStmt;
    using PrintStmt = domain.Statement.PrintStmt;
    using repository;
    using Test.domain.Statements;
    using Test.domain.DataType;
    using Test.controller;
    using System;
    using Test.domain.Expressions;
    using domain.Expression;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;

    public class Controller<T> : IController<T>
	{

        static object baton = new object();

		public IRepository<T> mRepo;

		public Controller(T stmt)
		{
			mRepo = new Repository<T>(SetStateList(stmt));
		}

		public List<PrgState<T>> SetStateList(T stmt)
		{
			MyList output = new MyList();
			MyDictionary symTable = new MyDictionary();
			MyStack<T> exeStack = new MyStack<T>();
            MyIHeap heap = new MyHeap();
			PrgState<T> prog = new PrgState<T>(exeStack, symTable, output, heap, 1);
            prog.AddExeStack(stmt);

            List<PrgState<T>> progList = new List<PrgState<T>>();

            progList.Add(prog);

            return progList;
		}

		public void AllStep()
		{

            while (true)
            {
                lock(baton)
                {
                    //remove the completed programs
                    List<PrgState<T>> prgList = RemoveCompletedPrg(mRepo.GetPrgList());
                    if (prgList.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        OneStepForAllPrg(prgList);
                    }
                }
            }

        }

        public void Serialize()
        {
            List<PrgState<T>> ps = mRepo.GetPrgList();
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Serialized.ser", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, ps);
                stream.Close();

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }
        }

        public void Deserialize()
        {
            List<PrgState<T>> ps = null;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Serialized.ser", FileMode.Open, FileAccess.Read, FileShare.None);
                ps = (List<PrgState<T>>)formatter.Deserialize(stream);
                stream.Close();

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }
            mRepo.SetPrgList(ps);
        }

        public List<PrgState<T>> GetProgramStateList()
        {

            return mRepo.GetPrgList();
        }

        public void DisplayAllStates()
        {
            throw new NotImplementedException();
        }

        //public void SetProgramState(PrgState<T> ps)
        //{
        //    mRepo.SetCrtPrg(ps);
        //}


        public List<PrgState<T>> RemoveCompletedPrg(List<PrgState<T>> inPrgList)
        {
            inPrgList.Where(p => p.IsNotCompleted());
            return inPrgList;
        }


        public void OneStepForAllPrg(List<PrgState<T>> prgList)
        {
            lock (baton)
            {
             
               

                prgList = RemoveCompletedPrg(mRepo.GetPrgList());

                //RUN concurrently one step for each of the existing PrgStates

                //verify for empty stacks


                //prepare the list of tasks
                List<Task<PrgState<T>>> taskList =
                    (from prg in prgList select Task<PrgState<T>>.Factory.StartNew(() => prg.OneStep())).ToList();

                //get the PrgState results
                List<PrgState<T>> newPrgList =
                    (from tsk in taskList where tsk.Result != null select tsk.Result).ToList();

                //add the newlly created threads to the list of the existing threads
                prgList.AddRange(newPrgList);

                //print the states after the execution
                foreach (PrgState<T> p in prgList) p.DisplayState();

                //save the current programs in repository
                mRepo.SetPrgList(prgList);
            }
        }


    }







}