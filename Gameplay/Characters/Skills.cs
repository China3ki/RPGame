namespace RPGGame.Gameplay.Characters
{
    internal class Skills(int strength, int luck, int fireResistance, int coldResistance, int darkResistance, int fireSkill, int coldSkill, int darkSkill, int swordSkill, int wandSkill, int bowSkill)
    {
        public int FreeSkillPoints { get; private set; } = 0;
        public int Strength { get; private set; } = strength;
        public int Luck { get; private set; } = luck;
        public int FireResistance { get; private set; } = fireResistance;
        public int ColdResistance { get; private set; } = coldResistance;
        public int DarkResistance { get; private set; } = darkResistance;
        public int FireSkill { get; private set; } = fireSkill;
        public int ColdSkill { get; private set; } = coldSkill;
        public int DarkSkill { get; private set; } = darkSkill;
        public int SwordSkill { get; private set; } = swordSkill;
        public int WandSkill { get; private set; } = wandSkill;
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
        /// <summary>
        /// Assigns a specified number of skill points to the given skill type.
        /// </summary>
        /// <param name="skillType">The type of skill to which points will be assigned.</param>
        /// <param name="pointsToAssign">The number of points to assign to the skill.</param>
        /// <returns>True if the points were successfully assigned; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the provided skill type does not exist.</exception>s
        public bool AssignSkillPoints(SkillsType skillType, int pointsToAssign)
        {
            if (pointsToAssign > FreeSkillPoints || pointsToAssign < 0) return false;
            switch (skillType)
            {
                case SkillsType.Strength: Strength += pointsToAssign; break;
                case SkillsType.Luck: Luck += pointsToAssign; break; 
                case SkillsType.FireResistance: FireResistance += pointsToAssign; break;
                case SkillsType.ColdResistance: ColdResistance += pointsToAssign; break;
                case SkillsType.DarkResistance: DarkResistance += pointsToAssign; break;
                case SkillsType.FireSkill: FireSkill += pointsToAssign; break;
                case SkillsType.ColdSkill: ColdSkill += pointsToAssign; break;
                case SkillsType.DarkSkill: DarkSkill += pointsToAssign; break;
                case SkillsType.SwordSkill: SwordSkill += pointsToAssign; break;
                case SkillsType.WandSkill: WandSkill += pointsToAssign; break;
                case SkillsType.BowSkill: BowSkill += pointsToAssign; break;
                default: throw new InvalidOperationException("That type of skill does not exist!");
            }
            return true;
        }
    }
}
