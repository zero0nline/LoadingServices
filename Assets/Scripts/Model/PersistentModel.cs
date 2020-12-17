using System;
using Data;
using Storage;
using Zenject;
using UniRx;

namespace Model
{
    public abstract class PersistentModel<T> where T : LoadData
    {
        [Inject] private IStorage _storage;
        [Inject] public T Model { get; }

        public Action ModelSaved;

        public IObservable<bool> Save()
        {
            var observable = _storage.Save(Model);
            observable.Subscribe(OnSaved);

            return observable;
        }

        public IObservable<bool> Load()
        {
            return _storage.Load(Model);
        }

        private void OnSaved(bool result)
        {
            if (result) ModelSaved?.Invoke();
        }
    }
}