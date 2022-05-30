// Strategy
//Стратегия — это поведенческий паттерн,
//выносит набор алгоритмов в собственные
//классы и делает их взаимозаменимыми.
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.Strategy.Conceptual
{
    class Context
    {
        private IStrategy _strategy;

        public Context()
        { }

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void BL()
        {
            var ran = new Random();
            var N = 10;
            var arr = new int[N];
            for (int i = 0; i < N; i++)
                arr[i] = ran.Next(0, 50);

            foreach (var item in arr)
                Console.Write(item + "\t");
            Console.WriteLine();

            var result = this._strategy.Sort(arr);
            
            foreach (var item in arr)
                Console.Write(item + "\t");
            Console.WriteLine();
            
        }
    }
   
    public interface IStrategy
    {
        object Sort(object data);
    }

    class SortA : IStrategy
    {
        public object Sort(object data)
        {
            var arr = data as int[];
            Array.Sort(arr);

            return arr;
        }
    }

    class SortB : IStrategy
    {
        public object Sort(object data)
        {
            var arr = data as int[];
            Array.Sort(arr);
            Array.Reverse(arr);

            return arr;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            Console.WriteLine("SortA");
            context.SetStrategy(new SortA());
            context.BL();

             Console.WriteLine();

            Console.WriteLine("SortB");
            context.SetStrategy(new SortB());
            context.BL();
        }
    }
}