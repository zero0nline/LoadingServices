using System;
using Data;

namespace Storage
{
    public class RemoteStorage : IStorage
    {
        public IObservable<bool> Load<T>(T model) where T : LoadData
        {
            //TODO:
            return null;
        }

        public IObservable<bool> Save<T>(T model) where T : LoadData
        {
            //TODO:
            return null;
        }
    }
}