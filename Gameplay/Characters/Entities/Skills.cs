using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using System.Diagnostics;

namespace RPGGame.Gameplay.Characters.Entities
{
    internal class Skills(int strength, int luck, int reflex, int magic, int fireSkill, int coldSkill, int darkSkill, int swordSkill, int wandSkill, int bowSkill)
    {
        public int FreeSkillPoints = 0;
        public int Strength { get; private set; } = strength;
        public int Luck { get; private set; } = luck;
        public int Reflex { get; private set; } = reflex;
        public int Magic { get; private set; } = magic;
        public int FireSkill { get; private set; } = fireSkill;
        public int ColdSkill { get; private set; } = coldSkill;
        public int DarkSkill { get; private set; } = darkSkill;
        public int SwordSkill { get; private set; } = swordSkill;
        public int WandSkill { get; private set; } = wandSkill;
        public int BowSkill { get; private set; } = bowSkill;
        public void SetFreeSkillPoints(int points) => FreeSkillPoints += points;
        private int RemoveFreeSkillPoints(int points)
        {
            FreeSkillPoints -= points;
            return points;
        }
        /// <summary>
        /// Distributes available skill points across various skill categories based on user input.
        /// </summary>
        /// <remarks>This method allows the user to allocate their free skill points to different skill
        /// categories, such as Strength, Luck, Reflex, and others. The user is prompted to assign points to each
        /// category, and they can confirm or cancel their allocation. If the allocation is canceled, the process
        /// restarts, and the previously allocated points are restored. The method ensures that the total allocated
        /// points do not exceed the available free skill points.</remarks>
        public void DistributeSkillPoints()
        {
            int decision;
            int saveFreePoints = FreeSkillPoints;
            Dictionary<SkillsCategory, int> tempSkill = [];
            do
            {
                tempSkill.Add(SkillsCategory.Strength, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Siła:", 0, FreeSkillPoints)));
                tempSkill.Add(SkillsCategory.Luck, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Szczęście:", 0, FreeSkillPoints)));
                tempSkill.Add(SkillsCategory.Reflex, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Refleks:", 0, FreeSkillPoints)));
                tempSkill.Add(SkillsCategory.Magic, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Magia:", 0, FreeSkillPoints)));
                tempSkill.Add(SkillsCategory.FireSkill, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Umiejętność władania ogniem:", 0, FreeSkillPoints)));
                tempSkill.Add(SkillsCategory.ColdSkill, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Umiejętność władania mrozem:", 0, FreeSkillPoints)));
                tempSkill.Add(SkillsCategory.DarkSkill, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Umiejętność władania ciemnością:", 0, FreeSkillPoints)));
                tempSkill.Add(SkillsCategory.SwordSkill, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Umiejętność władania mieczem:", 0, FreeSkillPoints)));
                tempSkill.Add(SkillsCategory.WandSkill, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Umiejętność władania rożdzką:", 0, FreeSkillPoints)));
                tempSkill.Add(SkillsCategory.BowSkill, RemoveFreeSkillPoints(InputHandler.SelectOption($"({FreeSkillPoints}) - Umiejętność władania łukiem:", 0, FreeSkillPoints)));
                View.RenderInfo("Chcesz zatwierdzić punkty?", ConsoleColor.Yellow);
                View.RenderInfo("1.Zatwierdź \n2.Anuluj", ConsoleColor.White);
                decision = InputHandler.SelectOption("Wybierz numer:", 1, 2);
                if (decision == 2)
                {
                    FreeSkillPoints = saveFreePoints;
                    tempSkill.Clear();
                }
            } while (decision == 2);
            foreach (var skill in tempSkill)
            {
                AssignFreePoints(skill.Value, skill.Key);
            }
        }
        /// <summary>
        /// Allocates a specified number of free skill points to a given skill category.
        /// </summary>
        /// <remarks>This method decreases the available free skill points by the specified amount after
        /// assigning them to the chosen skill category. Ensure that there are sufficient free skill points available
        /// before calling this method.</remarks>
        /// <param name="points">The number of points to assign to the specified skill category. Must be a positive value.</param>
        /// <param name="skill">The skill category to which the points will be assigned.</param>
        private void AssignFreePoints(int points, SkillsCategory skill)
        {
            switch(skill)
            {
                case SkillsCategory.Strength: Strength += points; break;
                case SkillsCategory.Luck: Luck += points; break;
                case SkillsCategory.Reflex: Reflex += points; break;
                case SkillsCategory.Magic: Magic += points; break;
                case SkillsCategory.FireSkill: FireSkill += points; break;
                case SkillsCategory.ColdSkill: ColdSkill += points; break;
                case SkillsCategory.DarkSkill: DarkSkill += points; break;
                case SkillsCategory.SwordSkill: SwordSkill += points; break;
                case SkillsCategory.WandSkill: WandSkill += points; break;
                case SkillsCategory.BowSkill: BowSkill += points; break;
            }
        }
    }
}
