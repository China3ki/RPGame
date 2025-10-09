using RPGGame.Components.Interfaces;

namespace RPGGame.Gameplay.Items
{
    internal class Potion(string name, string description, int weight, int price, int condition, int turnsEffect, int rottingSpeed, Rarity rarity, ItemType itemType, PotionType potionType) : Item(name, description, weight, price, condition, rarity, itemType), IUpdate
    {
        public PotionType PotionType { get; } = potionType;
        public int TurnsEffect { get; } = turnsEffect;
         private int _rottingSpeed = rottingSpeed;
        public void UpdateCondition()
        {
            if (Condition - _rottingSpeed <= 0) Condition = 0;
            else Condition -= _rottingSpeed;
        }
        public bool GetPotionValue()
        {
            if (Condition >= 30) return true;
            else return false;
        }
    }
}
