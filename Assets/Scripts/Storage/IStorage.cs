using System;
using Data;
using Model;

namespace Storage
{
    public interface IStorage
    {
        IObservable<bool> Load<T>(T model) where T : LoadData;
        IObservable<bool> Save<T>(T model) where T : LoadData;
    }
}