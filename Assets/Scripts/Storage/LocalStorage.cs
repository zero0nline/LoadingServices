using System;
using Data;
using Newtonsoft.Json;
using UniRx;
using UnityEngine;

namespace Storage
{
    public class LocalStorage : IStorage
    {
        public IObservable<bool> Load<T>(T model) where T : LoadData
        {
            var observable = Observable.CreateSafe<bool>(observer =>
            {
                var dataKeyName = model.KeyName;
                try
                {
                    //set default value for first run
                    if (!PlayerPrefs.HasKey(dataKeyName))
                    {
                        PlayerPrefs.SetString(dataKeyName,
                            JsonConvert.SerializeObject((T) model.GetDefaultValue(), Settings));
                    }

                    var stringValue = PlayerPrefs.GetString(dataKeyName);
                    JsonConvert.PopulateObject(stringValue, model, Settings);
                    
                    observer.OnNext(true);
                }
                catch (Exception e)
                {
                    observer.OnError(new Exception(
                        $"Error on load type {typeof(T)} by key '{dataKeyName}': {e.Message}\r\n{e.StackTrace}"));
                }

                return Disposable.Create(() => { });
            });

            return observable;
        }

        public IObservable<bool> Save<T>(T model) where T : LoadData
        {
            var observable = Observable.CreateSafe<bool>(observer =>
            {
                try
                {
                    var dataKeyName = model.KeyName;

                    PlayerPrefs.SetString(dataKeyName, JsonConvert.SerializeObject(model, Settings));
                    observer.OnNext(true);
                }
                catch (Exception e)
                {
                    observer.OnError(e);
                }

                return Disposable.Create(() => { });
            });

            return observable;
        }

        private static JsonSerializerSettings Settings =>
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
    }
}