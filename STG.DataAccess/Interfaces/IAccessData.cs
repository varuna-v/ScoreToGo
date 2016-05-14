using System;
using System.Collections.Generic;

namespace STG.DataAccess.Interfaces
{
    public interface IAccessData
    {
        void Save(object objectToStore);
        T GetFirst<T>(Func<T, bool> predicate);
        IEnumerable<T> GetMany<T>(Func<T, bool> predicate);
        IEnumerable<T> GetAll<T>();
    }
}
