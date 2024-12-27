using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<TestClass>();
        }
    }

    public class TestClass
    {
        [Benchmark]
        public void Run()
        {
            Console.WriteLine("111");
        }
    }
}
