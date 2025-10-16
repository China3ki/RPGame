namespace RPGGame.Gameplay.Characters.Managers
{
    internal class DamageManager
    {
        private Random _rnd = new();
        public int ReturnDamage(int weaponDamage, int luck, int skill, int weaponSkill)
        {
            if (_rnd.Next(0, 100) > luck + weaponSkill + 20) return 0;
            int dice = _rnd.Next(luck, luck + 3);
            int calcDamage = weaponDamage + (skill + weaponSkill / 5) + dice;
            if (Critic(luck)) return Convert.ToInt32(calcDamage * 1.5);
            else return calcDamage;
        }
        public int GetDamage(int damage, int protection, int luck, int reflex)
        {
            int dice = _rnd.Next(0, 100);
            if (dice > luck + reflex + 10) return damage - (protection / 2);
            else return 0;
        }
        private bool Critic(int luck)
        {
            int dice = _rnd.Next(0, 100);
            if (dice < luck + 15) return true;
            else return false;
        }
    }
}
