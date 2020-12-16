using UnityEngine;

namespace UI.Views
{
    public abstract class View<T> : MonoBehaviour
    {
        public virtual void SetData(T data)
        {
            
        }
    }
}