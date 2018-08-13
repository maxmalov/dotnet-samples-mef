using System.Composition;

namespace StandardClassLibrary
{
    public interface IService
    {
        void DoStuff();
    }

    [Export(typeof(IService))]
    internal class Service : IService
    {
        private readonly IWorker _worker;

        [ImportingConstructor]
        internal Service(IWorker worker)
        {
            _worker = worker;
        }

        public void DoStuff()
        {
            _worker.DoStuff();
        }
    }
}