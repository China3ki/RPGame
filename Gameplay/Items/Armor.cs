using RPGGame.Components.Interfaces;

namespace RPGGame.Gameplay.Items
{
    internal class Armor(string name, string description, int weight, int price, int condition, int protection, ItemType itemType, Rarity rarity, ArmorType armorType) : Item(name, description, weight, price, condition, rarity, itemType), IEquip
    {
        public ArmorType ArmorType = armorType;
        public bool Equipped { get; private set; } = false; 
        private int _protection = protection;
        public void HandleEquip() => Equipped = Equipped == false;
        public void UpdateCondition(int TakenDamage, int turns)
        {
            Random rnd = new();
            Condition -= turns + TakenDamage / 10 / rnd.Next(1, 10);
        }
        public int GetProtection()
        {
            double multiply = 1;
            if (Condition >= 60) multiply = 1;
            else if (Condition < 60 && Condition >= 30) multiply = 0.6;
            else if (Condition < 30) multiply = 0.3;
            return Convert.ToInt32(_protection * multiply);
        }
    }
}
