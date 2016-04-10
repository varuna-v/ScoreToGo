using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.AccessObjects.Raven
{
    public class RavenDocumentStoreHolder
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store
        {
            get { return store.Value; }
        }

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Url = System.Configuration.ConfigurationManager.AppSettings["RavenDocumentStoreUrl"],
                DefaultDatabase = System.Configuration.ConfigurationManager.AppSettings["RavenDatabaseName"]
            }.Initialize();

            return store;
        }
    }
}
