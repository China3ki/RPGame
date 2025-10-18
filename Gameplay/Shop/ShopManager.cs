using RPGGame.Components;
using RPGGame.Gameplay.Items;
using System;

namespace RPGGame.Gameplay.Shop
{
    static internal class ShopManager
    {
        static private ItemRandomizer _itemRandomizer = new();
        static private List<Item> _items = [];
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
            _items.AddRange(_itemRandomizer.RandomizeItems<Weapon>(ItemCategory.Weapon, 5));
            _items.AddRange(_itemRandomizer.RandomizeItems<Armor>(ItemCategory.Armor, 5));
            _items.AddRange(_itemRandomizer.RandomizeItems<Food>(ItemCategory.Food, 5));
            _items.AddRange(_itemRandomizer.RandomizeItems<Potion>(ItemCategory.Potion, 5));   
        }
    }
}
