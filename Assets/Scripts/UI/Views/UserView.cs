using Data;
using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class UserView : View<UserData>
    {
        [SerializeField] private TextMeshProUGUI userID;
        [SerializeField] private TextMeshProUGUI coins;
        [SerializeField] private TextMeshProUGUI level;

        public override void SetData(UserData data)
        {
            base.SetData(data);

            userID.text = data.userId;
            coins.text = data.coinsCount.ToString();
            level.text = data.currentLevel.ToString();
        }
    }
}