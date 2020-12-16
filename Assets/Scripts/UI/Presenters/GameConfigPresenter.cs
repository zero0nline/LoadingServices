using Model;
using UI.Views;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace UI.Presenters
{
    public class GameConfigPresenter : Presenter
    {
        [Inject] private GameConfig _gameConfig;
        private GameConfigView _view;
        
        public override void Show()
        {
            base.Show();

            _gameConfig.Load().Subscribe(OnLoad);
        }

        private void OnLoad(bool result)
        {
            if (result)
            {
                LoadView();
            }
            else
            {
                Debug.LogError($"Error on loading GameConfig");
            }
        }

        private void LoadView()
        {
            Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Views/GameConfigView.prefab").Completed += handle =>
            {
                if (handle.IsDone)
                {
                    _view = Object.Instantiate(handle.Result, Canvas.transform).GetComponent<GameConfigView>();
                    _view.SetData(_gameConfig.Model);
                }
            };
        }
    }
}