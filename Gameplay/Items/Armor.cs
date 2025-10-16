using RPGGame.Components.Interfaces;
using System.Text.Json.Serialization;

namespace RPGGame.Gameplay.Items
{
    internal class Armor(string name, int price, int weight, int durability, int itemId, int value, int minStrengthLevel, ArmorType armorType, Rarity rarity, ItemCategory itemCategory) : Item(name, price, weight, durability, itemId, rarity, itemCategory), IEquip
    {
        public int Value { get; } = value;
        public int MinStrengthLevel { get; } = minStrengthLevel;
        public bool Equipped { get; private set; } = false;
        public ArmorType ArmorType { get; } = armorType;
        public void HandleEquip() => Equipped = Equipped == false;
        public void UpdateDurability(int TakenDamage)
        {
            int durabilityLoss = TakenDamage / 5;
            if (Durability - durabilityLoss <= 0) Durability = 0;
            else Durability -= durabilityLoss;
        }
        public override int ReturnPrice()
        {
            float mulitply = 1;
            if (mulitply < 75 && mulitply >= 60) mulitply = .8f;
            else if (mulitply < 60 && mulitply >= 45) mulitply = .6f;
            else if (mulitply < 45 && mulitply >= 30) mulitply = .4f;
            else mulitply = .2f;
            return Convert.ToInt32(base.ReturnPrice() * mulitply);
        }
    }
}
