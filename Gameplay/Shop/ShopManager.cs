using RPGGame.Components;
using RPGGame.Gameplay.Items;
using System;

namespace RPGGame.Gameplay.Shop
{
    static internal class ShopManager
    {
        static private ItemRandomizer _itemRandomizer = new();
        static public List<Weapon> WeaponList { get; private set; } = [];
        static public List<Armor> ArmorList { get; private set; } = [];
        static public List<Food> FoodList { get; private set; } = [];
        static public List<Potion> PotionList { get; private set; } = [];
        static public List<Item> _items { get; private set; } = [];
        static public void RemoveAt(ItemCategory itemCategory, int index)
        {
            switch (itemCategory)
            {
                case ItemCategory.Weapon: WeaponList.RemoveAt(index); break;
                case ItemCategory.Armor: ArmorList.RemoveAt(index); break;
                case ItemCategory.Food: FoodList.RemoveAt(index); break;
                case ItemCategory.Potion: PotionList.RemoveAt(index); break;
            }
        }
        static public List<T> ReturnList<T>() where T : Item => _items.OfType<T>().ToList();

        static public void UpdateShop()
        {
             WeaponList = _itemRandomizer.RandomizeItems<Weapon>(ItemCategory.Weapon, 5);
             ArmorList = _itemRandomizer.RandomizeItems<Armor>(ItemCategory.Armor, 5);
             FoodList = _itemRandomizer.RandomizeItems<Food>(ItemCategory.Food, 5);
             PotionList = _itemRandomizer.RandomizeItems<Potion>(ItemCategory.Potion, 5);   
        }
    }
}
