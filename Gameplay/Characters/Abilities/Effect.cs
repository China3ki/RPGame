namespace RPGGame.Gameplay.Characters.Abilities
{
    internal class Effect(int value, int duration, EffectType effectType, EffectCategory effectCategory)
    {
        public int Value { get; private set; } = value;
        public int Duration { get; private set; } = duration;
        public EffectType EffectType { get; private set; } = effectType;
        public EffectCategory EffectCategory { get; private set; } = effectCategory;
        public void UpdateDuration() => Duration--;
        public void SetNewValue(int newValue) => Value = newValue;
        public void SetNewDuration(int newDuration) => Duration = newDuration;
    }
}
