using System;
using Commands;
using Data;
using Zenject;

namespace Model
{
    public abstract class PersistentModel<T> : IPersistent<T> where T : LoadData
    {
        [Inject] private LoadDataCommand.Factory _loadDataCommandFactory;

        [Inject] public T Model { get; }


        public IObservable<T> Save()
        {
            //TODO:
            return null;
        }

        public IObservable<bool> Load()
        {
            return _loadDataCommandFactory.Create().Execute(Model);
        }
    }
}