namespace RPGGame.Gameplay.Items
{
    internal class Food(string name, int price, int weight, int durability, int itemId, int value, Rarity rarity, ItemCategory itemCategory) : Item(name, price, weight, durability, itemId, rarity, itemCategory)
    {
        public int Value { get; } = value;      
        /// <summary>
        /// Updates the durability of the item by reducing it at a fixed rate.
        /// </summary>
        /// <remarks>If the durability falls below or equals zero after the reduction, it is set to zero.
        /// This method ensures that the durability does not become negative.</remarks>
        public void UpdateDurability()
        {
            int rottingSpeed = 3;
            if (Durability - rottingSpeed <= 0) Durability = 0;
            else Durability -= rottingSpeed;
        }
        public override int ReturnPrice()
        {
            float mulitply = 1;
            if (mulitply < 85 && mulitply >= 70) mulitply = .8f;
            else if (mulitply < 70 && mulitply >= 50) mulitply = .6f;
            else if (mulitply < 50 && mulitply >= 30) mulitply = .4f;
            else mulitply = .2f;
            return Convert.ToInt32(base.ReturnPrice() * mulitply);
        }
    }
}
