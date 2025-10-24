using RPGGame.Gameplay.Characters.Abilities;

namespace RPGGame.Gameplay.Characters.Managers
{
    internal class EffectManager()
    {
        public List<Effect> EffectList { get; private set; } = [];
        public void Update(Character character)
        {
            for(int i = 0; i < EffectList.Count; i++)
            {
                EffectList[i].UpdateDuration();
                HandleDamageEffect(EffectList[i].Value, EffectList[i].EffectType, character);
                if (EffectList[i].Duration == 0) HandleTempPointSkill(-EffectList[i].Value, EffectList[i].EffectType, character);
            }
            EffectList.RemoveAll(effect => effect.Duration == 0);
        }
        public void AddEffect(Effect effect, Character character)
        {
            if (effect.EffectType == EffectType.ClearNegativeEffects) EffectList.RemoveAll(effect => effect.EffectCategory == EffectCategory.Negative);
            Effect ?effectExist = EffectList.FirstOrDefault(oldEffect => oldEffect.EffectType == effect.EffectType);
            if(effectExist != null)
            {
                    effectExist.SetNewValue(effect.Value);
                    effectExist.SetNewDuration(effect.Duration);
                    return;
            }
            else EffectList.Add(effect);

            HandleTempPointSkill(effect.Value, effect.EffectType, character);
        }
        private void HandleTempPointSkill(int value, EffectType effectType, Character character)
        {
            switch(effectType)
            {
                case EffectType.FireSkill: character.Skills.AddTempPoints(value, SkillsCategory.FireSkill); break;
                case EffectType.ColdSkill: character.Skills.AddTempPoints(value, SkillsCategory.ColdSkill); break;
                case EffectType.DarkSkill: character.Skills.AddTempPoints(value, SkillsCategory.DarkSkill); break;
            }
        }
        private void HandleDamageEffect(int value, EffectType effectType, Character character)
        {
            if (effectType == EffectType.FireEffect || effectType == EffectType.ColdEffect || effectType == EffectType.DarkEffect) character.HandleHP(-value);
            else if (effectType == EffectType.HPRegeneration) character.HandleHP(value);
        }
    }
}
