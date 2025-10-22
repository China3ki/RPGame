using RPGGame.Components.Interfaces;

namespace RPGGame.Gameplay.Items
{
    class Weapon(string name, int price, int weight, int itemId, int durability, bool equipped, int value, int minWeaponLevel, SkillsCategory requiredSkillType, EffectType effectType, WeaponType weaponType, Rarity rarity, ItemCategory itemCategory) : Item(name, price, weight, durability, itemId, rarity, itemCategory), IEquip
    {
        public int Value { get; } = value;
        public int Level { get; } = minWeaponLevel;
        public bool Equipped { get; private set; } = equipped;
        public SkillsCategory RequiredSkillType { get; } = requiredSkillType;
        public EffectType EffectType { get; } = effectType;
        public WeaponType WeaponType { get; } = weaponType;
        public void HandleEquip() => Equipped = Equipped == false;
        public int GetDamage()
        {
            float mulitply = 1;
            if (Durability < 85 && Durability >= 70) mulitply = .9f;
            else if (Durability < 70 && Durability >= 55) mulitply = .7f;
            else if (Durability < 55 && Durability >= 45) mulitply = .5f;
            else if (Durability < 45 && Durability >= 30) mulitply = .3f;
            else if (Durability < 30) mulitply = .2f;
            return Convert.ToInt32(Value * mulitply);
        }
        public void UpdateDurability(int givenDamage)
        {
            int durabilityLoss = givenDamage / 10;
            if (Durability - durabilityLoss <= 0) Durability = 0;
            else Durability -= durabilityLoss;
        }
        public override int ReturnPrice()
        {
            float mulitply = 1;
            if (Durability < 75 && Durability >= 60) mulitply = .8f;
            else if (Durability < 60 && Durability >= 45) mulitply = .6f;
            else if (Durability < 45 && Durability >= 30) mulitply = .4f;
            else if (Durability < 30) mulitply = .2f;
            return Convert.ToInt32(base.ReturnPrice() * mulitply);
        }
    }
}
