using Raven.Client;
using Raven.Client.Linq;
using STG.DataAccess.AccessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace STG.DataAccess.AccessObjects.Raven
{
    public class RavenDataAccess : IAccessData
    {
        public void Save(object objectToStore)
        {
            using (IDocumentSession session = RavenDocumentStoreHolder.Store.OpenSession())
            {
                session.Store(objectToStore);
                session.SaveChanges();
            }
        }

        public T GetFirst<T>(Func<T, bool> predicate)
        {
            using (IDocumentSession session = RavenDocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<T>().Where(x => predicate(x)).FirstOrDefault();
            }
        }

        public IEnumerable<T> GetMany<T>(Func<T, bool> predicate)
        {
            using (IDocumentSession session = RavenDocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<T>().Where(x => predicate(x));
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            using (IDocumentSession session = RavenDocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<T>();
            }
        }
    }
}
