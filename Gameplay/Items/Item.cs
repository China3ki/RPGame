namespace RPGGame.Gameplay.Items
{
    class Item(string name, string description, int weight, int price, int condition, Rarity rarity, ItemType itemType)
    {
        public string Name { get; } = name;
        public string Description { get; } = description;
        public int Weight { get; } = weight;
        public int Price { get; } = price;
        public int Condition { get; protected set; } = condition;
        public ItemType ItemType { get; } = itemType;
        public Rarity Rarity { get; } = rarity;
        public int GetPrice()
        {
            double multiply = 1;
            if (Condition >= 85) multiply = 1;
            else if (Condition < 85 && Condition >= 65) multiply = 0.8;
            else if (Condition < 65 && Condition >= 45) multiply = 0.6;
            else if (Condition < 45 && Condition >= 30) multiply = 0.5;
            else if (Condition < 30) multiply = 0.3;
            return Convert.ToInt32(Price * multiply);
        }
    }
}
