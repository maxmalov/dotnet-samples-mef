using System;
using System.Composition;

namespace StandardClassLibrary
{
    internal interface IWorker
    {
        void DoStuff();
    }

    [Export(typeof(IWorker))]
    internal class Worker : IWorker
    {
        public void DoStuff()
        {
            Console.WriteLine("Doing stuff, press any key to stop");
            Console.ReadLine();
        }
    }
}