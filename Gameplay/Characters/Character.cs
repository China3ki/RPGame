using RPGGame.Gameplay.Characters.Entities;
using RPGGame.Gameplay.Characters.Managers;

namespace RPGGame.Gameplay.Characters
{
    internal class Character(string name, int hp, int level, Skills skills, Inventory inventory)
    {
        public string Name { get; } = name;
        public int HP { get; private set; } = hp;
        public int Level { get; private set; } = level;
        public Skills Skills { get; private set; } = skills;
        public Inventory Inventory { get; private set; } = inventory;
        public DamageManager DamageManger { get; private set; } = new();
        public void AddHP(int HPPoints)
        {
            if (HP + HPPoints > 100) HP = 100;
            else HP += HPPoints;
        }
    }
}
