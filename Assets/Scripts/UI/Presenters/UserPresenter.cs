using Model;
using UI.Views;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Presenters
{
    public class UserPresenter : Presenter<UserView>
    {
        [Inject] private User _user;

        protected override string ViewPrefabPath => "Assets/Prefabs/Views/UserView.prefab";

        public override void Show()
        {
            base.Show();

            _user.Load().Subscribe(OnLoad);
        }

        private void OnLoad(bool result)
        {
            if (result)
            {
                LoadView().Completed += handle => { View.SetData(_user.Model); };
            }
            else
            {
                Debug.LogError($"Error on loading User");
            }
        }
    }
}