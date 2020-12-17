using Model;
using UI.Views;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Presenters
{
    public class GameConfigPresenter : Presenter<GameConfigView>
    {
        [Inject] private GameConfig _gameConfig;
        protected override string ViewPrefabPath => "Assets/Prefabs/Views/GameConfigView.prefab";

        public override void Show()
        {
            base.Show();

            _gameConfig.Load().Subscribe(OnLoad);
        }

        private void OnLoad(bool result)
        {
            if (result)
            {
                LoadView().Completed += handle => { View.SetData(_gameConfig.Model); };
            }
            else
            {
                Debug.LogError($"Error on loading GameConfig");
            }
        }
    }
}