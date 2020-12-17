using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace UI.Presenters
{
    public abstract class Presenter<T> where T : MonoBehaviour
    {
        [Inject] protected Canvas Canvas;

        protected T View;

        protected abstract string ViewPrefabPath { get; }

        public virtual void Show()
        {
        }

        protected AsyncOperationHandle<GameObject> LoadView()
        {
            var asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(ViewPrefabPath);
            asyncOperationHandle.Completed += handle =>
            {
                if (handle.IsDone)
                {
                    View = Object.Instantiate(handle.Result, Canvas.transform).GetComponent<T>();
                }
                else
                {
                    //catch error
                }
            };

            return asyncOperationHandle;
        }
    }
}