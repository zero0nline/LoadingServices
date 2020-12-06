using System;
using System.Collections.Generic;

namespace Data
{
    [Serializable]
    public class GameData : LoadData
    {
        public int maxLevel;
        public List<string> shopItems;

        public override string KeyName => "GameConfig";

        public override LoadData GetDefaultValue()
        {
            return new GameData
                {maxLevel = 99, shopItems = new List<string> {"item_1", "item_2", "item_3"}};
        }
    }
}