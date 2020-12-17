using Data;

namespace Model
{
    public class User : PersistentModel<UserData>
    {
        public void AddCoins(int value)
        {
            Model.coinsCount += value;
            Save();
        }

        public void IncreaseLevel()
        {
            Model.currentLevel++;
            Save();
        }
    }
}