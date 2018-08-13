using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using StandardClassLibrary;

namespace ConsoleApp
{
    internal class Program : IDisposable
    {
        private readonly CompositionContainer _container;

        [Import(typeof(IService))] public IService Service { get; private set; }

        private Program()
        {
            //An aggregate catalog that combines multiple catalogs  
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class  
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IService).Assembly));

            //Create the CompositionContainer with the parts in the catalog  
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object  
            try
            {
                _container.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void Main()
        {
            using (var p = new Program())
            {
                p.Service.DoStuff();
            }
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
