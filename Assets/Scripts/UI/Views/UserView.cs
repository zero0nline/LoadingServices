using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class UserView : View<UserData>
    {
        [SerializeField] private TextMeshProUGUI userID;
        [SerializeField] private TextMeshProUGUI coins;
        [SerializeField] private TextMeshProUGUI level;

        [SerializeField] private Button addCoinsBtn;
        [SerializeField] private Button increaseLevelBtn;

        public Button AddCoinsBtn => addCoinsBtn;
        public Button IncreaseLevelBtn => increaseLevelBtn;
        
        public override void SetData(UserData data)
        {
            base.SetData(data);

            userID.text = data.userId;
            coins.text = data.coinsCount.ToString();
            level.text = data.currentLevel.ToString();
        }
    }
}