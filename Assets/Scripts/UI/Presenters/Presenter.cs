using UnityEngine;
using Zenject;

namespace UI.Presenters
{
    public abstract class Presenter
    {
        [Inject] protected Canvas Canvas;
        
        public virtual void Show()
        {
            
        }
    }
}