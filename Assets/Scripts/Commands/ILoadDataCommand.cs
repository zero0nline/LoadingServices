using System;
using Data;

namespace Commands
{
    public interface ILoadDataCommand
    {
        IObservable<bool> Execute<T>(T model) where T : LoadData;
    }
}