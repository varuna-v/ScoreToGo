using Raven.Client;
using Raven.Client.Document;
using System;

namespace STG.DataAccess.Raven
{
    public class RavenDocumentStoreHolder
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store
        {
            get
            {
                if (store == null)
                    CreateStore();
                return store.Value;
            }
        }

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Url = System.Configuration.ConfigurationManager.AppSettings["RavenDataStoreUrl"],
                DefaultDatabase = System.Configuration.ConfigurationManager.AppSettings["RavenDatabaseName"]
            }.Initialize();

            return store;
        }
    }
}
