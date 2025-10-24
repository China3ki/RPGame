using RPGGame.Gameplay.Characters.Abilities;

namespace RPGGame.Gameplay.Characters.Managers
{
    internal class SpellsManager
    {
        public List<Effect> LearnedSpellList { get; private set; } = [];
        public Effect[] ActiveSpells { get; private set; } = new Effect[4];
        public void LearnSpell(Effect effect) => LearnedSpellList.Add(effect);
        public void ActivateSpell(int slot, int index) => ActiveSpells[slot] = LearnedSpellList[index];
    }
}
