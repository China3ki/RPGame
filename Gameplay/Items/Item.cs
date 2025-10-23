using System.Text.Json.Serialization;

namespace RPGGame.Gameplay.Items
{
    internal class Item(string name, int price, int weight, int durability, int itemId, Rarity rarity, ItemCategory itemCategory )
    {
        public string Name { get; } = name;
        public int Weight { get; } = weight;
        public int Durability { get; protected set; } = durability;
        public Rarity Rarity { get; } = rarity;
        public ItemCategory ItemCategory { get; } = itemCategory;
        protected Dictionary<Rarity, float> _priceMultiply = new() { { Rarity.Common, 1 }, { Rarity.Uncommon, 1.5f }, { Rarity.Rare, 2.5f }, { Rarity.Epic, 3.5f }, { Rarity.Legendary, 4f } };
        protected int _price = price;
        private int ItemId = itemId;

        /// <summary>
        /// Calculates and returns the price of the item based on its rarity and a predefined multiplier.
        /// </summary>
        /// <remarks>The price is determined by multiplying the base price by a rarity-specific
        /// multiplier.</remarks>
        /// <returns>The calculated price as an integer.</returns>
        public virtual int ReturnPrice() => Convert.ToInt32(_price * _priceMultiply[Rarity]);
    }
}
