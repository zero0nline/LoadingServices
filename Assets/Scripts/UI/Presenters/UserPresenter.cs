using Model;
using UI.Views;
using UniRx;
using UnityEngine;

namespace UI.Presenters
{
    public class UserPresenter : Presenter<UserView>
    {
        private readonly User _user;

        protected override string ViewPrefabPath => "Assets/Prefabs/Views/UserView.prefab";

        public UserPresenter(User user)
        {
            _user = user;
            _user.ModelSaved += OnModelSaved;
        }
        
        public override void Show()
        {
            base.Show();

            _user.Load().Subscribe(OnLoad);
        }

        private void OnLoad(bool result)
        {
            if (result)
            {
                LoadView().Completed += handle =>
                {
                    View.SetData(_user.Model);
                    View.AddCoinsBtn.onClick.AddListener(OnAddCoinsBtnClick);
                    View.IncreaseLevelBtn.onClick.AddListener(OnIncreaseLevelBtnClick);
                };
            }
            else
            {
                Debug.LogError($"Error on loading User");
            }
        }
        
        private void OnModelSaved()
        {
            View.SetData(_user.Model);
        }

        private void OnAddCoinsBtnClick()
        {
            _user.AddCoins(100);
        }

        private void OnIncreaseLevelBtnClick()
        {
            _user.IncreaseLevel();
        }
    }
}