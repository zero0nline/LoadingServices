using System;
using Data;
using Storage;
using Zenject;

namespace Model
{
    public abstract class PersistentModel<T> where T : LoadData
    {
        [Inject] private IStorage _storage;
        [Inject] public T Model { get; }
        
        public IObservable<T> Save()
        {
            //TODO:
            return null;
        }

        public IObservable<bool> Load()
        {
            return _storage.Load(Model);
        }
    }
}