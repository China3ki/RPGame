namespace RPGGame.Gameplay.Characters
{
    internal class Skills(int strength, int luck, int fireResistance, int coldResistance, int darkResistance, int swordSkill, int wandSkill, int bowSkill)
    {
        public int FreeSkillPoints { get; private set; } = 0;
        public int Strength { get; private set; } = strength;
        public int Luck { get; private set; } = luck;
        public int FireResistance { get; private set; } = fireResistance;
        public int ColdResistance { get; private set; } = coldResistance;
        public int DarkResistance { get; private set; } = darkResistance;
        public int SwordSkill { get; private set; } = swordSkill;
        public int WandSKill { get; private set; } = wandSkill;
        public int BowSkill { get; private set; } = bowSkill;
        /// <summary>
        /// Sets the number of available (free) skill points for the player or character.
        /// </summary>
        /// <param name="skillPoints">
        /// The new number of free skill points to assign.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the provided number of skill points is zero or negative.
        /// </exception>
        public void SetFreeSkillPoints(int skillPoints)
        {
            if (skillPoints > 0) FreeSkillPoints = skillPoints;
            else throw new InvalidOperationException("New number of skill points cannot be negative or zero!");
        }
        public void 
    }
}
