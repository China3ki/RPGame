using RPGGame.Components.Interfaces;

namespace RPGGame.Gameplay.Items
{
    internal class Food(string name, string description, int weight, int price, int condition, int foodValue, int rottingSpeed, Rarity rarity, ItemType itemType) : Item(name, description, weight, price, condition, rarity, itemType), IUpdate
    {
        public int FoodValue { get; } = foodValue;
        private int _rottingSpeed = rottingSpeed;
        public void UpdateCondition()
        {
            if (Condition - _rottingSpeed <= 0) Condition = 0;
            else Condition -= _rottingSpeed;
        }
        public int GetFoodValue()
        {
            float multiply = 1;
            if (Condition >= 90) multiply = 1;
            else if (Condition < 90 && Condition >= 70) multiply = 0.8f;
            else if (Condition < 70 && Condition >= 50) multiply = 0.5f;
            else if (Condition < 50 && Condition >= 30) multiply = 0.3f;
            else if (Condition < 30) return -1;
            return Convert.ToInt32(multiply * FoodValue);
        }
    }
}
