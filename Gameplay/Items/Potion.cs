namespace RPGGame.Gameplay.Items
{
    internal class Potion(string name, int price, int weight, int durability, int itemId, int value, int duration, EffectType effectType, Rarity rarity, ItemCategory itemCategory) : Item(name, price, weight, durability, itemId, rarity, itemCategory)
    {
        public int Value { get; } = value;
        public int Duration { get; } = duration;
        public EffectType EffectType { get; } = effectType;
    }
}
