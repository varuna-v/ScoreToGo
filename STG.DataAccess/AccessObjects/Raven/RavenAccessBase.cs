using Raven.Client;
using STG.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Raven.Client.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.AccessObjects.Raven
{
    public abstract class RavenAccessBase
    {
        protected void Store(RavenDocumentBase document)
        {
            using (IDocumentSession session = RavenDocumentStoreHolder.Store.OpenSession())
            {
                session.Store(document);
                session.SaveChanges();
            }
        }

        protected T Retreive<T>(Func<T, bool> predicate)
        {
            using (IDocumentSession session = RavenDocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<T>().Where(x => predicate(x)).FirstOrDefault();
            }
        }
    }
}
