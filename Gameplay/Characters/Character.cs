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
        public EffectManager EffectManager { get; private set; } = new();
        public SpellsManager SpellManager { get; private set; } = new();
        public void HandleHP(int HPPoints)
        {
            if (HP + HPPoints > 100) HP = 100;
            else if (HP + HPPoints < 0) HP = 0;
            else HP += HPPoints;
        }
    }
}
