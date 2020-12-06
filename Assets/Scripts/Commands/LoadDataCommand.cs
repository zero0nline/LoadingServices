using System;
using Data;
using Storage;
using Zenject;

namespace Commands
{
    public class LoadDataCommand
    {
        private IStorage _storage;

        public LoadDataCommand(IStorage storage)
        {
            _storage = storage;
        }

        public IObservable<bool> Execute<T>(T model) where T : LoadData
        {
            return _storage.Load(model);
        }

        public class Factory : PlaceholderFactory<LoadDataCommand>
        {
        }
    }
}