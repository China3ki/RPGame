namespace RPGGame.Gameplay.Items
{
    internal class Weapon(string name, string description, int weight, int price, int condition, int fastDamage, int hardDamage, int minLevel, Rarity rarity, ItemType itemType, WeaponType weaponType) : Item(name, description, weight, price, condition, rarity, itemType)
    {
        public WeaponType WeaponType { get; } = weaponType;
        public int MinLevel { get; } = minLevel;
        public bool Equipped { get; private set; } = false;
        private int _fastDamage = fastDamage;
        private int _hardDamage = hardDamage;
        public void HandleEquip() => Equipped = Equipped == false;
        public void UpdateCondition(int turns)
        {
            Random rnd = new();
            Condition -= turns + rnd.Next(1, 10);
        }
        public int GetDamage(AttackType attackType)
        {
            double multiply = 1;
            if (Condition >= 80) multiply = 1;
            else if (Condition < 80 && Condition >= 65 ) multiply = 0.8;
            else if (Condition < 65 && Condition >= 30) multiply = 0.5;
            else if (Condition < 30) multiply = 0.3;
            if (attackType == AttackType.FastAttack) return Convert.ToInt32(_fastDamage * multiply);
            else return Convert.ToInt32(_hardDamage * multiply);
        }
    }
}
