using System;

namespace Data
{
    [Serializable]
    public class UserData : LoadData
    {
        public string userId;
        public int coinsCount;
        public int currentLevel;

        public override string KeyName => "User";

        public override LoadData GetDefaultValue()
        {
            return new UserData
            {
                userId = "id_1",
                coinsCount = 1000,
                currentLevel = 1
            };
        }
    }
}