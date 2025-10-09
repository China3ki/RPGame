namespace RPGGame.Gameplay.Characters
{
    internal class Character(string name, int hp, int level, Skills skills, Inventory inventory)
    {
        public string Name { get; private set; } = name;
        public int Hp { get; private set; } = hp;
        public int Level { get; private set; } = level;
        public Skills Skills { get; private set; } = skills;
        public Inventory Inventory { get; private set; } = inventory;
        public List<Tuple<int, EffectType>> ActiveEffects { get; private set; } = [];
        private Random _rnd = new();
        public int DealDamage(int weaponAttack, AttackType attackType, WeaponType weaponType)
        {
            Dictionary<WeaponType, int> WeaponSkills = new() { { WeaponType.Sword, Skills.SwordSkill }, { WeaponType.Wand, Skills.WandSkill }, { WeaponType.Bow, Skills.BowSkill } };
            const int fastAttackMultipier = 1;
            const int fastAttackDivider = 7;
            const int hardAttackMultipier = 3;
            const int hardAttackDivider = 3;
            int fastAttack = (fastAttackMultipier * weaponAttack + fastAttackMultipier * Skills.Strength + fastAttackMultipier * WeaponSkills[weaponType]) / fastAttackDivider + _rnd.Next(Skills.Luck, Skills.Luck + 10);
            int hardAttack = (hardAttackMultipier * weaponAttack + hardAttackMultipier * Skills.Strength + hardAttackMultipier * WeaponSkills[weaponType]) / hardAttackDivider + _rnd.Next(Skills.Luck, Skills.Luck + 10);
            int damage = attackType == AttackType.FastAttack ? fastAttack : hardAttack;
            bool critic = _rnd.Next(0, 100) < Skills.Luck / 2;
            if (_rnd.Next(0, 100) > Skills.Luck + 40 && attackType == AttackType.FastAttack) return 0;
            else if (_rnd.Next(0, 100) > Skills.Luck + 20 && attackType == AttackType.HardAttack) return 0;
            if (critic) return damage * 2;
            else return damage;
        }
        public int GetDamage(int damage)
        {
            int helmetProtection = Inventory.Helmet == null ? 0 : Inventory.Helmet.GetProtection();
            int chestplateProtection = Inventory.Chestplate == null ? 0 : Inventory.Chestplate.GetProtection();
            int leggingsProtection = Inventory.Leggings == null ? 0 : Inventory.Leggings.GetProtection();
            int bootsProtection = Inventory.Boots == null ? 0 : Inventory.Boots.GetProtection();
            int protection = helmetProtection + chestplateProtection + leggingsProtection + bootsProtection;
            int calcDamage;
            if (damage - protection < 0) calcDamage = _rnd.Next(0, 5 + Skills.Luck / 2);
            else calcDamage = damage - (protection / 2);
            if (_rnd.Next(0, 100) > Skills.Luck + 10)
            {
                Hp -= calcDamage;
                return calcDamage;
            }
            else return -1;
        }
        public bool GetEffect(EffectType effect)
        {
            Dictionary<EffectType, int> resistanceSkills = new() { { EffectType.Fire, Skills.FireResistance }, { EffectType.Cold, Skills.ColdResistance }, { EffectType.Dark, Skills.DarkResistance } };
            if (_rnd.Next(0, 100) > Skills.Luck + resistanceSkills[effect] + 10)
            {
                ActiveEffects.Add(Tuple.Create(_rnd.Next(2, 5), effect));
                return true;
            }
            else return false;
        }
        public bool DealEffect(EffectType effect)
        {
            Dictionary<EffectType, int> effectSkills = new() { { EffectType.Fire, Skills.FireSkill }, { EffectType.Cold, Skills.ColdSkill }, { EffectType.Dark, Skills.DarkSkill } };
            if (_rnd.Next(0, 100) > Skills.Luck + effectSkills[effect] + 20) return false;
            else return true;
        }
    }
}
