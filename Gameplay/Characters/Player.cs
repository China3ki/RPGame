using RPGGame.Gameplay.Characters.Entities;
using System.Text;

namespace RPGGame.Gameplay.Characters
{
    internal class Player(string name, int hp, int level, int xp, int coins, string savePath, Skills skills, Inventory inventory) : Character(name, hp, level, skills, inventory)
    {
        public int XP { get; private set; } = xp;
        public int Coins { get; private set; } = coins;
        public string SavePath { get; private set; } = savePath;
        public void RemoveCoins(int points) => Coins -= points;
        public void GeneratePlayerId()
        {
            StringBuilder saveName = new("save");
            Random rnd = new();
            for (int i = 0; i < 6; i++) saveName.Append(rnd.Next(0, 10));
            SavePath = saveName.ToString();
        }
    }
}
