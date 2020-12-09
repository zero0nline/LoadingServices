using System;
using Data;
using Storage;

namespace Commands
{
    public abstract class AbstractLoadDataCommand : ILoadDataCommand
    {
        private IStorage _storage;
        
        protected AbstractLoadDataCommand(IStorage storage)
        {
            _storage = storage;
        }
        
        public IObservable<bool> Execute<T>(T model) where T : LoadData
        {
            return _storage.Load(model);
        }
    }
}