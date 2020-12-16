using Data;
using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class GameConfigView : View<GameData>
    {
        [SerializeField] private TextMeshProUGUI maxLevelValue;
        [SerializeField] private TextMeshProUGUI itemsValue;

        public override void SetData(GameData data)
        {
            base.SetData(data);

            maxLevelValue.text = data.maxLevel.ToString();
            itemsValue.text = string.Join(",", data.shopItems);
        }
    }
}