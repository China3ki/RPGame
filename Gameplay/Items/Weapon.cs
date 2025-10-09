using RPGGame.Components.Interfaces;

namespace RPGGame.Gameplay.Items
{
    internal class Weapon(string name, string description, int weight, int price, int condition, int fastDamage, int hardDamage, int minLevel, Rarity rarity, ItemType itemType, WeaponType weaponType, EffectType effectType) : Item(name, description, weight, price, condition, rarity, itemType), IEquip
    {
        public WeaponType WeaponType { get; } = weaponType;
        public EffectType EffectType { get; } = effectType;
        public int MinLevel { get; } = minLevel;
        public bool Equipped { get; private set; } = false;
        public int _fastDamage = fastDamage;
        public int _hardDamage = hardDamage;
        public void HandleEquip() => Equipped = Equipped == false;
        /// <summary>
        /// Updates the condition (durability) of the item over a given number of turns.
        /// The condition decreases by the number of turns plus a random degradation value.
        /// </summary>
        /// <param name="turns">The number of turns that have passed since the last update.</param>
        public void UpdateCondition(int turns)
        {
            Random rnd = new();
            Condition -= turns + rnd.Next(1, 10);
        }

        /// <summary>
        /// Calculates the effective damage dealt based on the current condition of the item
        /// and the type of attack performed.
        /// </summary>
        /// <param name="attackType">The type of attack (e.g. Fast or Hard).</param>
        /// <returns>
        /// The total damage value adjusted by the item's condition multiplier.
        /// </returns>
        public int ReturnDamage(AttackType attackType)
        {
            double multiply = 1;
            if (Condition >= 80) multiply = 1;
            else if (Condition < 80 && Condition >= 65) multiply = 0.8;
            else if (Condition < 65 && Condition >= 30) multiply = 0.5;
            else if (Condition < 30) multiply = 0.3;
            if (attackType == AttackType.FastAttack) return Convert.ToInt32(_fastDamage * multiply);
            else return Convert.ToInt32(_hardDamage * multiply);
        }

    }
}
